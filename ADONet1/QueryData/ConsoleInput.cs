using System;
using System.Collections.Generic;
using System.Data;

namespace ADONet1.QueryData
{
    class ConsoleInput
    {
        const string Keyword = "exit";

        public int GetNumberOfQuery()
        {
            while (true)
            {
                int number;

                Console.WriteLine("Введите номер запроса или наберите 'exit' для выхода:");

                string num = Console.ReadLine();

                if (Keyword == num)
                {
                    Environment.Exit(0);
                }
                else if (Int32.TryParse(num, out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод, сделайте правильный выбор!");
                }
            }
        }

        public string GetTextOfQuery(List<string> list, int number)
        {
            string query = list[number - 1];
            return query;
        }
    }
}