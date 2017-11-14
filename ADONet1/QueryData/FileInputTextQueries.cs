using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ADONet1.QueryData
{
    class FileInputTextQueries
    {
        public List<string> GetQueriesList()
        {
            List<string> queriesList = new List<string>();
            try
            {
                //using (StreamReader sr = new StreamReader("Queries.txt"))
                //{
                    
                //}
                queriesList = File.ReadAllLines("Queries.txt", Encoding.GetEncoding(1251)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return queriesList;
        }
    }
}