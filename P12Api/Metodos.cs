using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace P12Api
{
    public class Metodos
    {
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