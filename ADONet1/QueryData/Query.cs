using System.Collections.Generic;

namespace ADONet1.QueryData
{
    class Query
    {
        public int Number { get; set; }

        public string TextQuery { get; set; }

        public Query(int number, string textQuery)
        {
            Number = number;
            TextQuery = textQuery;
        }
    }
}