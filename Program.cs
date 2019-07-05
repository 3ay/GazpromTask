using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleNew
{
    class Program
    {
        public static void Main()
        {
            HtmlParser obj = new HtmlParser();
            obj.HtmlParse();
            ConnectionDB con = new ConnectionDB();
            con.Connection();
        }
    }
}
