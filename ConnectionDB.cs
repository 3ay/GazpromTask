using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;

namespace ExampleNew
{
    class ConnectionDB
    {
        public static void Connection(Energy eng)
        {
            string connectionString = @"Host=iap-01-bidb02.ogk.energo.local;Username=postgres;Password=postgres;Database=postgres;";
                //@"Server = iap-01-bidb02.ogk.energo.local;User Id = postgres;Password=postgres;Port=5432; Database= postgres;";
            //
            //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            //{
            //    connection.Open();
            //    Console.WriteLine("Подключение открыто");
            //            // Вывод информации о подключении
            //     //Console.WriteLine("Свойства подключения:");
            //     //Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
            //     //Console.WriteLine("\tБаза данных: {0}", connection.Database);
            //     //Console.WriteLine("\tСервер: {0}", connection.DataSource);
            //     //Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
            //     //Console.WriteLine("\tСостояние: {0}", connection.State);    

            //        }
            //    Console.WriteLine("Подключение закрыто...");
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
           connection.Open();
                string sql = "INSERT INTO dbo.energy(name_branch, power_value) VALUES (@b.NameOfBranch, @b.PowerValue)";
                foreach (var b in eng.getTableObj())
                {
                    using (NpgsqlCommand npgSqlCommand = new NpgsqlCommand(sql, connection))
                    {
                        npgSqlCommand.Parameters.AddWithValue("@b.NameOfBranch", NpgsqlTypes.NpgsqlDbType.Varchar, b.NameOfBranch);
                        npgSqlCommand.Parameters.AddWithValue("@b.PowerValue", NpgsqlTypes.NpgsqlDbType.Varchar, b.PowerValue);


                int Count = npgSqlCommand.ExecuteNonQuery();
                if (Count == 1)
                       Console.WriteLine("запись вставлена");
                   else
                       Console.WriteLine("не удалось вставить новую запись");
                   

                    }
                }
                connection.Close();
                Console.Write(eng.getTableObj().Count);
                Console.ReadLine();
            }
                
        }
    }
        //  string connectionString = @"Data Source=.\Main;Initial Catalog=postgres;Integrated Security=True";
        
}
    

   
   
