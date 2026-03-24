using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace _11_Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Something");

            //var factory = new SqlFactory("Server=OVO-YD2YXBFUANE\\SQLEXPRESS;Database=TEST_DB;Integrated Security=True;");
            //
            //using(var conn = factory.CreateConnection())
            //{
            //    conn.Open();
            //
            //    var tx = factory.CreateTransation(conn);
            //    var cmd = factory.CreateCommand(conn);
            //
            //    cmd.Transaction = tx;
            //    cmd.CommandText = "INSERT INTO regional_sales (region, id, amount) VALUES (@region, @id, @amount)";
            //
            //
            //    cmd.Parameters.Add(new SqlParameter("@region", "japan"));
            //    cmd.Parameters.Add(new SqlParameter("@id", "11"));
            //    cmd.Parameters.Add(new SqlParameter("@amount", "220"));
            //
            //    try
            //    {
            //        cmd.ExecuteNonQuery();
            //        tx.Commit();
            //    }
            //    catch
            //    {
            //        tx.Rollback();
            //        throw;
            //    }
            //}

            var factory = new SqliteFactory("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            
            using (var conn = factory.CreateConnection())
            {
                conn.Open();
            
                var tx = factory.CreateTransation(conn);
                var cmd = factory.CreateCommand(conn);
            
                cmd.Transaction = tx;
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        Age INTEGER
                    );
                    ";
            
                cmd.Parameters.Add(new SqlParameter("@Id", "22"));
                cmd.Parameters.Add(new SqlParameter("@Name", "Roman"));
                cmd.Parameters.Add(new SqlParameter("@Age", "35"));
            
                try
                {
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }

            Console.ReadLine();
        }
    }

    interface IDbFactory
    {
        IDbConnection CreateConnection(); 
        IDbCommand CreateCommand(IDbConnection conn);
        IDbTransaction CreateTransation(IDbConnection conn);
    }

    class SqlFactory : IDbFactory
    {
        private readonly string _connectionString;
        public SqlFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public IDbCommand CreateCommand(IDbConnection conn)
        {
            return conn.CreateCommand();
        }

        public IDbTransaction CreateTransation(IDbConnection conn)
        {
            return conn.BeginTransaction();
        }
    }

    class SqliteFactory : IDbFactory
    {
        private readonly string _connectionString;
        public SqliteFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        public IDbCommand CreateCommand(IDbConnection conn)
        {
            return conn.CreateCommand();
        }

        public IDbTransaction CreateTransation(IDbConnection conn)
        {
            return conn.BeginTransaction();
        }
    }
}
