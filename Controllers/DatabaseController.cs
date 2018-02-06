using System;
using System.Data.SqlClient;

/// <summary>
/// controls database connections and queries
/// </summary>
namespace Microsoft.Bot.Sample.Database
{
    public class DatabaseController
    {
        private string connetionString;
        private SqlConnection connection;
        private SqlCommand command;

        /// <summary>
        /// default constructor
        /// </summary>
        public DatabaseController()
        {
            connetionString = Environment.GetEnvironmentVariable("MyDB");
            Connect();
        }

        /// <summary>
        /// open connection
        /// </summary>
        public void Connect()
        {
            connection = new SqlConnection(connetionString);
            connection.Open();
        }

        /// <summary>
        /// return query results (currently hard coded for testing purposes)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public string GetQueryResult(string query)
        {
            query = "SELECT TOP 1 * FROM dbo.Posts ORDER BY id DESC";
            return Query(query);
        }

        /// <summary>
        /// execute query and return the results
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private string Query(string sql)
        {
            string queryResult = null;
            SqlDataReader dataReader;

            command = new SqlCommand(sql, connection);
            dataReader = command.ExecuteReader();
            queryResult = dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2);
            dataReader.Close();
            command.Dispose();
            connection.Close();

            return queryResult;
        }
    }
}