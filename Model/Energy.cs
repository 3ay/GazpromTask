using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace ExampleNew
{
    [Table(Name="energy")]
    class Energy
    {
       
      
        public string NameOfBranch { get; set; }
         [Column(Name = "PowerValue")]
        public string PowerValue { get; set; }

        private List<Energy> TableObj = new List<Energy>();

        public List<Energy> getTableObj()
        {
            return TableObj;
        }
      
    }
}
