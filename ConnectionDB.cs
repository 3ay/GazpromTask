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
        public void Connection()
        {
    string connectionString = @"Server = iap-01-bidb02.ogk.energo.local;User Id = postgres;Password=postgres;Port=5432; Database= postgres;";
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
            HtmlParser hp = new HtmlParser();
            List<Energy> notesK = new List<Energy>();
            List<Energy> notesV = new List<Energy>();
            for (int i = 0;i<hp.getListKey().Count;i++)
            {

                notesK[i] = new Energy { NameOfBranch = hp.getListKey()[i] };
                notesV[i] = new Energy { PowerValue = hp.getListValue()[i] };
                
           // db.GetTable<Energy>().InsertAllOnSubmit(notes);
            }

           NpgsqlCommand npgSqlCommand = new NpgsqlCommand("INSERT INTO Energy(NameOfBranch, PowerValue) VALUES (@notesK, @notesV)", connection);
           NpgsqlParameter npgSqlParameterKey = new NpgsqlParameter("@notesK", NpgsqlTypes.NpgsqlDbType.Varchar);
           NpgsqlParameter npgSqlParameterValue = new NpgsqlParameter("@notesV", NpgsqlTypes.NpgsqlDbType.Varchar);
           for (int i = 0; i < hp.getListKey().Count; i++)
           {
           npgSqlParameterKey.Value = notesV[i];
           npgSqlParameterValue.Value = notesK[i];
           npgSqlCommand.Parameters.AddRange(new NpgsqlParameter[] { npgSqlParameterKey,
           npgSqlParameterValue});  
           }
                int count = npgSqlCommand.ExecuteNonQuery();
                if (count == 1)
                    Console.WriteLine("Запись вставлена");
                else
                    Console.WriteLine("Не удалось вставить новую записаь");
                connection.Close();
                Console.ReadKey(true);

                // db.SubmitChanges();
                Console.ReadLine();
            }
                
        }
    }
        //  string connectionString = @"Data Source=.\Main;Initial Catalog=postgres;Integrated Security=True";
        
}
    

   
   
