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
    public class PagamentosController : ApiController
    {
        ICollection<Pagamentos> pg = new List<Pagamentos>();

        [EnableCors(origins: "*", headers: "*", methods: "*")]

        // GET: api/Pagamentos
        public IEnumerable<Pagamentos> Get()
        {
            return pg;
        }

        // GET: api/Pagamentos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pagamentos
        public Pagamentos Post([FromBody]Pagamentos value)
        {
            DataBase db = new DataBase();
            DataSet ds = new DataSet();

            var x = value;
            int apto = int.Parse(x.Apartamento);
            string data = DateTime.Now.ToShortDateString();
            //int idApartamento = LocalizaId(localizaId);

            //CLASSE RETORNA ID DO APARTAMENTO
            LocalizaId buscaId = new LocalizaId();
            int idApartamento = buscaId.Localiza("select id from tblApartamento where Numero = " + apto + "");

            string select = "select * from tblPagamentos where IdApartamento = " + idApartamento + "";

            ds = db.GetDataSet(select);

            if (ds.Tables[0].Rows.Count.Equals(0))
            {
                //INSERT
                string insert = "insert into tblPagamentos values(" + idApartamento + ", '" + data + "', '" + x.Janeiro + "', '" + x.Fevereiro + "', '" + x.Marco + "', '" + x.Abril + "', '" + x.Maio + "', '" + x.Junho + "', '" +
                    x.Julho + "', '" + x.Agosto + "', '" + x.Setembro + "', '" + x.Outubro + "', '" + x.Novembro + "', '" + x.Dezembro + "')";

                db.ExecuteCommand(insert);
            }
            else
            {
                //UPDATE
                string update = "update tblPagamentos set Janeiro = '" + x.Janeiro + "', Fevereito = '" + x.Fevereiro + "', Marco = '" + x.Marco + "', Abril = '" + x.Abril + "', Maio = '" + x.Maio + "', Junho = '" + x.Junho + "', Julho = '" +
                    x.Julho + "', Agosto = '" + x.Agosto + "', Setembro = '" + x.Setembro + "', Outubro = '" + x.Outubro + "', Novembro = '" + x.Novembro + "', Dezembro = '" + x.Dezembro + "' where IdApartamento = " + idApartamento + "";

                db.ExecuteCommand(update);
            }

            AtualizaCaixa(idApartamento);

            return value;
        }

        // PUT: api/Pagamentos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pagamentos/5
        public void Delete(int id)
        {
        }

        //ATUALIZA A TABELA TBLCAIXA
        protected void AtualizaCaixa(int idApartamento)
        {
            DataBase db = new DataBase();
            DataSet ds = new DataSet();

            string selectValores = "select Valor from tblValores";
            ds = db.GetDataSet(selectValores);

            decimal valor = (decimal)ds.Tables[0].Rows[0].ItemArray.ElementAt(0);

            string insertValor = "insert into tblCaixa values(" + idApartamento + ", 50.00)";
            db.ExecuteCommand(insertValor);
        }

        //private int LocalizaId(int IdApartamento)
        //{
        //    DataBase db = new DataBase();
        //    DataSet ds = new DataSet();

        //    string select = "select id from tblApartamento where Numero = " + IdApartamento + "";

        //    ds = db.GetDataSet(select);

        //    int id = (int)ds.Tables[0].Rows[0].ItemArray.ElementAt(0);

        //    return id;
        //}
    }
}
