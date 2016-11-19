using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace P12Api.Controllers
{
    public class CadastroController : ApiController
    {
        // GET: api/Cadastro
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cadastro/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cadastro
        public string Post([FromBody]Condominos value)
        {
            Metodos meusMetodos = new P12Api.Metodos();
            DataBase db = new DataBase();
            bool retorno;

            if (value != null)
            {
                //VERIFICA E-MAIL
                if (value.Nome == null || value.Email == null || value.Telefone == null || value.Senha == null)
                {
                    return "Favor Preencher todos os campos";
                }

                retorno = meusMetodos.VerificaEmail(value.Email);
                if (retorno)
                {
                    return "Já existe um E-mail " + value.Email + " cadastrado!";
                }

                //VERIFICA RESPONSAVEL
                if (value.Responsavel)
                {
                    retorno = meusMetodos.VerificaResponsavel(value.Apartamento);
                    if (retorno)
                    {
                        return "Já existe um responsável cadastrado para o apartamento este apartamento" + value.Apartamento;
                    }
                }

                //VERIFICA SINDICO
                if (value.Sindico)
                {
                    retorno = meusMetodos.VerificaSindico();
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
                        int id = meusMetodos.DescobreId(value.Email);
                        string update = "update tblApartamento set IdCondonimo = " + id + ", Ocupacao = 'true' where Numero = " + value.Apartamento + " ";
                        db.ExecuteCommand(update);
                    }

                    return "Cadastrado com sucesso!";
                }
                catch (Exception ex)
                {
                    return "Erro ao Cadastrar";
                    //throw;
                }
            }
            else
            {
                return "Erro ao Cadastrar";
            }
        }

        // PUT: api/Cadastro/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cadastro/5
        public void Delete(int id)
        {
        }
    }
}
