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
        
       public static Energy HtmlParse()
        {
           
            
            HtmlAgilityPack.HtmlDocument HD = new HtmlAgilityPack.HtmlDocument();

            WebClient client = new WebClient();
            var data = client.DownloadData("http://localhost/example/index.html");
            var html = Encoding.UTF8.GetString(data);
            Energy eng = new Energy();
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
                    Linker.AddLast(nodes.ElementAt(i).InnerText.Trim());    
                }
                
                {
                for (int index=0;index<Linker.Count();index++)
                {
                  
            eng.getTableObj().Add(new Energy { NameOfBranch = Linker.ElementAt(index), PowerValue = Linker.ElementAt(index+1)});
                        index++;
                }

                }
                foreach (var cl in eng.getTableObj())
                {
                    Console.WriteLine(cl.NameOfBranch +": "+ cl.PowerValue);
                }
                //for (int a=0;a<Key.Count;a++)
                //Console.WriteLine(Key[a]+": "+Value[a]+"\n");
                
            }
            // Console.ReadLine();
            return eng;
        }
    }
}
