using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace ExampleNew
{
    class HtmlParser
    {
        private List<string> Key = new List<string>();
        private List<string> Value = new List<string>();
        public List<string> getListKey()
        {
            return Key;
        }
        public List<string> getListValue()
        {
            return Value;
        }
       public void HtmlParse()
        {
           
            
            HtmlAgilityPack.HtmlDocument HD = new HtmlAgilityPack.HtmlDocument();

            WebClient client = new WebClient();
            var data = client.DownloadData("http://localhost/example/index.html");
            var html = Encoding.UTF8.GetString(data);

            HD.LoadHtml(html);
            //http://localhost/example/index.html
            //C:/inetpub/wwwroot/example/index.html
            var c = HD.DocumentNode.SelectSingleNode(@"/html/body/table/tbody");          
            if (c != null)
            {
                var nodes = c.SelectNodes("//td");
                
                LinkedList<string> Linker = new LinkedList<string>();

               
                for (int i = 0; i < nodes.Count(); i++)
                {
                    Linker.AddLast(nodes[i].InnerText.Trim());    
                }
                for (int k=0;k<Linker.Count();k++)
                {
                    if(k%2==0)
                    {
                        getListKey().Add(Linker.ElementAt(k));
                    }
                    else if (k%2!=0)
                    {
                        getListValue().Add(Linker.ElementAt(k));
                    }
                }
                for (int a=0;a<Key.Count;a++)
                Console.WriteLine(Key[a]+": "+Value[a]+"\n");
                
            }
           // Console.ReadLine();
        }
    }
}
