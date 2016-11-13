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
    public class ValorCondominioController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        // GET: api/ValorCondominio
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ValorCondominio/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ValorCondominio
        public void Post([FromBody]ValorCaixa value)
        {
            DataBase db = new DataBase();
            string update = " update tblValores set Valor = " + value.Valor + "sssss";

            db.ExecuteCommand(update);

        }

        // PUT: api/ValorCondominio/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ValorCondominio/5
        public void Delete(int id)
        {
        }
    }
}
