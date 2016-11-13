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
    public class ValorCaixaController : ApiController
    {
        ICollection<ValorCaixa> lstValor = new List<ValorCaixa>();

        [EnableCors(origins: "*", headers: "*", methods: "*")]

        // GET: api/ValorCaixa
        public IEnumerable<ValorCaixa> Get()
        {
            DataBase db = new DataBase();
            DataSet ds = new DataSet();
            ValorCaixa v = new ValorCaixa();
            string sum = "select sum(Valor) from tblCaixa";
            string select = "select Valor from tblCaixa ";

            //VERIFIANDO DE A TABELA VALORES ESTÁ VAZIA
            ds = db.GetDataSet(select);

            if (ds.Tables[0].Rows.Count != 0)
            {
                ds = db.GetDataSet(sum);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {                   
                    v.Valor = (decimal)ds.Tables[i].Rows[i].ItemArray.ElementAt(i);

                    lstValor.Add(v);
                }
            }
            else
            {
                v.Valor = 0;
                lstValor.Add(v);
            }
           

            return lstValor;
        }

        // GET: api/ValorCaixa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ValorCaixa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ValorCaixa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ValorCaixa/5
        public void Delete(int id)
        {
        }
    }
}
