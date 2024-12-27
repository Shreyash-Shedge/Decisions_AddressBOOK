using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;
using AddressBook.ORM.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AddressBook.ORM.OrmLayer
{
    public class GenericHelper : IGenericHelper
    {
        private readonly IConfiguration Configuration;

        public GenericHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<T> FetchData<T>(string query, Func<SqlDataReader, T> mapFunction, params SqlParameter[] parameters)
        {
            List<T> results = new List<T>();

            string? constr = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                results = ExecuteQuery<T>(connection, query, mapFunction, parameters);
                connection.Close();
            }

            return results;
        }

        public void AddRecord(string query, params SqlParameter[] parameters)
        {
            ExecuteNonQuery(query, parameters);
        }

        public void DeleteRecord(string query, params SqlParameter[] parameters)
        {
            ExecuteNonQuery(query, parameters);
        }

        public void UpdateRecord(string query, params SqlParameter[] parameters)
        {
            ExecuteNonQuery(query, parameters);
        }

        private void ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            string? constr = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
        }

        private List<T> ExecuteQuery<T>(SqlConnection connection, string query, Func<SqlDataReader, T> mapFunction, SqlParameter[] parameters)
        {
            List<T> results = new List<T>();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(mapFunction(reader));
                    }
                }
            }
            return results;
        }
    }
}
