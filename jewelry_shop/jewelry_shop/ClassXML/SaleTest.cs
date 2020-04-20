using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jewelry_shop.ClassXML
{
    public class SaleTest
    {
        public string TitleName { get; set; }
        public string TitleType { get; set; }
        public string SName { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string SaleDate { get; set; }

        public SaleTest(string TitleName, string TitleType, string SName, string Name, string FName, string SaleDate) 
        {
            this.TitleName = TitleName;
            this.TitleType = TitleType;
            this.SName = SName;
            this.Name = Name;
            this.FName = FName;
            this.SaleDate = SaleDate;
        }

    }
}
