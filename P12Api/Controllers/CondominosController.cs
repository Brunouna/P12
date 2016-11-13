using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace P12Api.Controllers
{
    public class CondominosController : ApiController
    {
        ICollection<Condominos> lstCondominos = new List<Condominos>();

        [EnableCors(origins: "*", headers: "*", methods: "*")]

        // GET: api/Condominos
        public IEnumerable<Condominos> Get()
        {
            DataSet ds = new DataSet();
            DataBase db = new DataBase();

            string select = "SELECT * FROM tblCondominos";

            ds = db.GetDataSet(select);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Condominos condominos = new Condominos();

                condominos.Id = (int)ds.Tables[0].Rows[i].ItemArray.ElementAt(0);
                condominos.Nome = ds.Tables[0].Rows[i].ItemArray.ElementAt(1).ToString();
                condominos.Email = ds.Tables[0].Rows[i].ItemArray.ElementAt(2).ToString();
                condominos.Telefone = ds.Tables[0].Rows[i].ItemArray.ElementAt(3).ToString();
                condominos.Responsavel = (bool)ds.Tables[0].Rows[i].ItemArray.ElementAt(4);
                condominos.Sindico = (bool)ds.Tables[0].Rows[i].ItemArray.ElementAt(5);
                condominos.Senha = ds.Tables[0].Rows[i].ItemArray.ElementAt(6).ToString();

                lstCondominos.Add(condominos);
            }

            return lstCondominos;
        }

        // GET: api/Condominos/5
        public Condominos Get(int id)
        {
            DataSet ds = new DataSet();
            DataBase db = new DataBase();

            string select = "SELECT * FROM tblCondominos WHERE Id = " + id.ToString();

            ds = db.GetDataSet(select);


            Condominos condominos = new Condominos();

            condominos.Id = (int)ds.Tables[0].Rows[0].ItemArray.ElementAt(0);
            condominos.Nome = ds.Tables[0].Rows[0].ItemArray.ElementAt(1).ToString();
            condominos.Email = ds.Tables[0].Rows[0].ItemArray.ElementAt(2).ToString();
            condominos.Telefone = ds.Tables[0].Rows[0].ItemArray.ElementAt(3).ToString();
            condominos.Responsavel = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(4);
            condominos.Sindico = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(5);
            condominos.Senha = ds.Tables[0].Rows[0].ItemArray.ElementAt(6).ToString();


            return condominos;
        }

        // POST: api/Condominos
        public string Post([FromBody]Condominos value)
        {
            DataBase db = new DataBase();
            bool retorno;

            //VERIFICA E-MAIL
            if (value.Nome == null || value.Email == null || value.Telefone == null || value.Senha == null)
            {
                return "Favor Preencher todos os campos";
            }

            retorno = VerificaEmail(value.Email);
            if (retorno)
            {
                return "Já existe um E-mail " + value.Email + " cadastrado!";
            }

            //VERIFICA RESPONSAVEL
            if (value.Responsavel)
            {
                retorno = VerificaResponsavel(value.Apartamento);
                if (retorno)
                {
                    return "Já existe um responsável cadastrado para o apartamento " + value.Apartamento;
                }
            }

            //VERIFICA SINDICO
            if (value.Sindico)
            {
                retorno = VerificaSindico();
                if (retorno)
                {
                    return "Já existe um sindico cadastrado para o prédio";
                }
            }

            try
            {               
                var condominos = value;

                string insert = "INSERT INTO tblCondominos VALUES('" + condominos.Nome + "', '" + condominos.Telefone + "', '" + condominos.Email + "', '" + condominos.Responsavel + "', '" + condominos.Sindico + "', '" + condominos.Senha + "', " + condominos.Apartamento + ")";

                db.ExecuteCommand(insert);

                //UPDATE SE FOR RESPONSAVEL NA TABELA APARTAMENTOS
                if (value.Responsavel)
                {
                    int id = DescobreId(value.Email);
                    string update = "update tblApartamento set IdCondonimo = " + id + ", Ocupacao = 'true' where Numero = " + value.Apartamento + " ";
                    db.ExecuteCommand(update);
                }
               

                return "Cadastrado com sucesso!";
            }
            catch (Exception ex)
            {

                throw;
            }              
           
          }

        // PUT: api/Condominos/5
        public void Put(int id, [FromBody]Condominos value)
        {
        }

        // DELETE: api/Condominos/5
        public void Delete(int id)
        {
        }

        //VERRIFICA SE EXISTE E-MAIL CADASTRADO
        public bool VerificaEmail(string Email)
        {
            DataBase db = new DataBase();
            DataSet ds = new DataSet();

            string select = "select Email from tblCondominos where Email = '" + Email + "'";

            ds = db.GetDataSet(select);

            if (ds.Tables[0].Rows.Count != 0)
            {
                return ds.Tables[0].Rows[0].ItemArray.Any();
            }

            return false;
        }

        public bool VerificaResponsavel(string apartamento)
        {
            DataBase db = new DataBase();
            DataSet ds = new DataSet();
            string select = "select Responsavel from tblCondominos where Apartamento = " + apartamento + " and Responsavel = 'true'";

            ds = db.GetDataSet(select);

            if (ds.Tables[0].Rows.Count != 0)
            {
                return ds.Tables[0].Rows[0].ItemArray.Any();
            }

            return false;
        }

        public bool VerificaSindico()
        {
            DataBase db = new DataBase();
            DataSet ds = new DataSet();
            string select = "select sindico from tblCondominos where sindico = 'true'";

            ds = db.GetDataSet(select);

            if (ds.Tables[0].Rows.Count != 0)
            {
                return ds.Tables[0].Rows[0].ItemArray.Any();
            }

            return false;
        }

        public int DescobreId(string email)
        {
            DataBase db = new DataBase();
            DataSet ds = new DataSet();
            int retorno = 0;
            string select = "select id from tblCondominos where Email = '" + email + "'";

            ds = db.GetDataSet(select);

            if (ds.Tables[0].Rows.Count != 0)
            {
                retorno = (int)ds.Tables[0].Rows[0].ItemArray.ElementAt(0);
            }

            return retorno;
        }
    }
}
