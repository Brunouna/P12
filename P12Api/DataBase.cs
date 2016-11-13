using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace P12Api
{
    public class DataBase
    {

        private SqlConnection _db;

        public SqlConnection DB
        {
            get { return _db; }
        }

        public DataBase()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public DataSet GetDataSet(string SQL)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = _db.CreateCommand();
            cmd.CommandText = SQL;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            _db.Open();
            da.Fill(ds);
            _db.Close();

            return ds;
        }

        //tables[0].Rows.Count

        public void ExecuteCommand(string SQL)
        {
            SqlCommand cmd = _db.CreateCommand();
            cmd.CommandText = SQL;

            _db.Open();

            cmd.ExecuteNonQuery();
            _db.Close();
        }              
    }
}

//lstCondominos.Add(new Condominos() {
//    Id = 0,
//    Nome = "Bruno",
//    Telefone = "0000-0000",
//    Email= "bruno@emc.com.br",
//    Senha = "123",
//    Responsavel = true,
//    Sindico = false 
//});