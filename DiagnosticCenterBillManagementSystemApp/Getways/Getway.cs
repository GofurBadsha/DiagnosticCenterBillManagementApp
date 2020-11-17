using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Getways
{
    public class Getway
    {
        public string ConnectionString()
        {
            var connectionString = @"Server=KING;Database=DiagnosticCenterDb;User Id=sa;Password=2018;";
            return connectionString;
        }

        public int ExecuteNoneQuery(string query, string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(query, connection);
            int success = command.ExecuteNonQuery();
            connection.Close();
            return success;
        }

        public SqlDataReader Reader(string query, string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(query, connection);
            return command.ExecuteReader();
        }


    }
}
