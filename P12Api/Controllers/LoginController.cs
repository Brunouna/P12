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
    public class LoginController : ApiController
    {
        ICollection<Login> lstLogin = new List<Login>();

        [EnableCors(origins: "*", headers: "*", methods: "*")]

        // GET: api/Login
        public IEnumerable<Login> Get([FromBody]Login value)
        {
            DataBase db = new DataBase();
            DataSet ds = new DataSet();

           // string select = "SELECT * FROM tblCondominos WHERE Nome = '"+value.Email+"' AND Senha = '"+value.Senha+"'";

            return lstLogin;
        }

        // GET: api/Login/5
        public Login Get(int id, [FromBody]Login value)
        {
            return value;
        }

        // POST: api/Login
        public IEnumerable<Login> Post([FromBody]Login value)
        {
            DataBase db = new DataBase();
            DataSet ds = new DataSet();

            string select = "SELECT * FROM tblCondominos WHERE Email = '" + value.Email + "' AND Senha = '" + value.Senha + "'";

            ds = db.GetDataSet(select);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                Login l = new Login();

                l.Id = (int)ds.Tables[0].Rows[0].ItemArray.ElementAt(7);
                l.Email = ds.Tables[0].Rows[0].ItemArray.ElementAt(1).ToString();
                l.Senha = ds.Tables[0].Rows[0].ItemArray.ElementAt(6).ToString();
                l.Sindico = (bool)ds.Tables[0].Rows[0].ItemArray.ElementAt(5);

                lstLogin.Add(l);
            }

           
            return lstLogin;
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
