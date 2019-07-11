using Example2.Model;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Example2
{
    class ExelParse
    {
        public static  Price ExelParser()
        {
            List<string> Dlist = new List<string>();
              string file = "C:/inetpub/wwwroot/example/price_rsv.xlsx";
            //http://localhost/example/price_rsv.xlsx
           // System.Net.WebClient wc = new System.Net.WebClient();
           //wc.DownloadString(url);
            FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read);
            
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            Price pr = new Price();
            foreach (DataTable table in result.Tables)
            {
                Console.WriteLine(table.Rows.Count+"\n");
                Console.WriteLine(table.Columns.Count + "\n");
                //Console.WriteLine(table.TableName + "\n");
                //for (int i=0;i<table.Rows.Count;i++)
                //{
                //    Console.WriteLine(table.Rows[i].ItemArray[0]+": "+table.Rows[i].ItemArray[1]);
                //}
                for (int i=0;i<table.Rows.Count;i++)
                {
                    pr.GetNodes().Add(new Price { Affilate = table.Rows[i].ItemArray[0].ToString(),Price_rsv=table.Rows[i].ItemArray[1].ToString() });
                  //  Console.WriteLine(pr.GetNodes().ElementAt(i).Affilate+": "+pr.GetNodes().ElementAt(i).Price_rsv);
                }
            }

            return pr;
               
            
        }
    }
}
