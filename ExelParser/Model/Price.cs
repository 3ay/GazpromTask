using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace Example2.Model
{
    [Table(Name = "price_rsv")]
    class Price
    {
        [Column(Name="affilate")]
        public string Affilate { get; set; }
        [Column(Name = "price_rsv")]
        public string Price_rsv { get; set; }

        private List<Price> Nodes { get; set; } 

        public Price()
        {
            Nodes = new List<Price>();
        }
        public List<Price> GetNodes()
        {
            return Nodes;
        }
    }
}
