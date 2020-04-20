using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jewelry_shop.ClassXML
{
    public class ProductTest
    {
        public string materialname { get; set; }
        public string titlename { get; set; }
        public string TitleType { get; set; }
        public string Weight { get; set; }
        public string Price { get; set; }

        public ProductTest(string materialname, string TitleType, string titlename, string Weight, string Price) 
        {
            this.materialname = materialname;
            this.titlename = titlename;
            this.TitleType = TitleType;
            this.Weight = Weight;
            this.Price = Price;
        }
    }
}
