using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jewelry_shop.ClassXML
{
    public class TitleTest
    {
        public string Titleid { get; set; }
        public string TitleName { get; set; }
        public string TitleType { get; set; }

        public TitleTest(String Titleid, string TitleName, string TitleType)
        {
            this.Titleid = Titleid;
            this.TitleName = TitleName;
            this.TitleType = TitleType;
        }
    }
}
