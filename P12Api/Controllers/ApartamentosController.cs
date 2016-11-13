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
    public class ApartamentosController : ApiController
    {
        ICollection<Apartamentos> ap = new List<Apartamentos>();

        [EnableCors(origins: "*", headers: "*", methods: "*")]

        // GET: api/Apartamentos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Apartamentos/5
        public Apartamentos Get(int id)
        {
            DataBase db = new DataBase();
            DataSet ds = new DataSet();
            Apartamentos apto = new Apartamentos();

            //CLASSE RETORNA ID DO APARTAMENTO
            LocalizaId bunscaId = new LocalizaId();
            int idApartamento = bunscaId.Localiza("select id from tblApartamento where Numero = " + id + "");

            string select = "select * from tblPagamentos where IdApartamento = " + idApartamento + "";
            ds = db.GetDataSet(select);

            if (ds.Tables[0].Rows.Count != 0)
            {
                apto.Janeiro = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(3);
                apto.Fevereiro = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(4);
                apto.Marco = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(5);
                apto.Abril = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(6);
                apto.Maio = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(7);
                apto.Junho = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(8);
                apto.Julho = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(9);
                apto.Agosto = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(10);
                apto.Setembro = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(11);
                apto.Outubro = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(12);
                apto.Novembro = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(13);
                apto.Dezembro = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(14);

            }

            //JOIN QUE BUSCAS DOS DADOS DOS CONDOMINOS PARA O PAGAMENTO
            string join = "select Numero ,Nome, Email, Telefone from tblCondominos inner join tblApartamento on tblCondominos.Id = tblApartamento.IdCondonimo where tblApartamento.Numero = '" + id + "'";

            ds = db.GetDataSet(join);

            if (ds.Tables[0].Rows.Count != 0)
            {
                apto.Numero = (int)ds.Tables[0].Rows[0].ItemArray.ElementAt(0);
                apto.Nome = ds.Tables[0].Rows[0].ItemArray.ElementAt(1).ToString();
                apto.Email = ds.Tables[0].Rows[0].ItemArray.ElementAt(2).ToString();
                apto.Telefone = ds.Tables[0].Rows[0].ItemArray.ElementAt(3).ToString();
            }

            return apto;
        }

        // POST: api/Apartamentos
        public void Post([FromBody]Apartamentos value)
        {

        }

        // PUT: api/Apartamentos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apartamentos/5
        public void Delete(int id)
        {
        }
    }
}
