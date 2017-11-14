using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ADONet1.QueryData
{
    class SqlQuery
    {
        public int NumberOfQuery { get; set; }

        public string TextOfQuery { get; set; }

        public string ConnectionString { get; set; }

        public Query Query { get; set; }

        public List<string> Queries { get; set; }

        public SqlQuery()
        {
            InitListQuery();
            while (true)
            {
                InitDataQuery();
                RunAndPrintQuery(Query);
            }
        }

        private void InitListQuery()
        {
            FileInputTextQueries FileInput = new FileInputTextQueries();
            Queries = FileInput.GetQueriesList();
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void InitDataQuery()
        {
            ConsoleInput inputData = new ConsoleInput();
            NumberOfQuery = inputData.GetNumberOfQuery();
            TextOfQuery = inputData.GetTextOfQuery(Queries, NumberOfQuery);
            Query = new Query(NumberOfQuery, TextOfQuery);
        }

        private void RunAndPrintQuery(Query query)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query.TextQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write("{0, -10} \t", reader.GetName(i));
                    }
                    
                    Console.WriteLine();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            object value = reader.GetValue(i);

                            Console.Write("{0, -10} \t", value);
                        }
                        Console.WriteLine();
                    }
                }

                reader.Close();
            }
            Console.ReadLine();
        }
    }
}