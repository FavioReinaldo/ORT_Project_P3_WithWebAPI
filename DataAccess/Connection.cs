using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Connection : IDbConnection
    {

        SqlConnection con = null;

        private string connectionString = "data source=LAPTOP-THPBMDUC; database=ObligaotrioProgramacion3; integrated security=true";
        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public int ConnectionTimeout => con.ConnectionTimeout;

        public Connection()
        {
            con = new SqlConnection(connectionString);
        }
        public string Database => con.Database;

        public ConnectionState State => con.State;

        public IDbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            con.Close();
        }

        public IDbCommand CreateCommand()
        {
            return con.CreateCommand();
        }

        public void Dispose()
        {
            con.Dispose();
        }

        public void Open()
        {
            con.Open();
        }
    }
}
