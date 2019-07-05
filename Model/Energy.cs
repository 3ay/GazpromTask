using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace ExampleNew
{
    [Table(Name="Energy")]
    class Energy
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
      
        public string NameOfBranch { get; set; }
         [Column(Name = "PowerValue")]
        public string PowerValue { get; set; }
    }
}
