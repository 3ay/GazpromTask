using Example2.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    class Connection
    {
        public static void ConnectionDB (Price pr)
        {
            string connectionString = @"Host=iap-01-bidb02.ogk.energo.local;Username=postgres;Password=postgres;Database=postgres;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO dbo.price_rsv(affilate, price_rsv) VALUES (@b.Affilate, @b.Price_rsv)";
                foreach (var b in pr.GetNodes())
                {
                    using (NpgsqlCommand npgSqlCommand = new NpgsqlCommand(sql, connection))
                    {
                        npgSqlCommand.Parameters.AddWithValue("@b.Affilate", NpgsqlTypes.NpgsqlDbType.Varchar, b.Affilate);
                        npgSqlCommand.Parameters.AddWithValue("@b.Price_rsv", NpgsqlTypes.NpgsqlDbType.Varchar, b.Price_rsv);


                        int Count = npgSqlCommand.ExecuteNonQuery();
                        if (Count == 1)
                            Console.WriteLine("запись вставлена");
                        else
                            Console.WriteLine("не удалось вставить новую запись");


                    }
                }
                connection.Close();
                Console.Write(pr.GetNodes().Count);
                Console.ReadLine();
            }
        }
             
    }
}
