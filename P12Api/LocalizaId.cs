
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace P12Api
{
    public class LocalizaId
    {       
        public int Localiza(string sql)
        {
            DataBase db = new DataBase();
            DataSet ds = new DataSet();

            string select = sql;

            ds = db.GetDataSet(select);

            int id = (int)ds.Tables[0].Rows[0].ItemArray.ElementAt(0);

            return id;
        }
    }
}