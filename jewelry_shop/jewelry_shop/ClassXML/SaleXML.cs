using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jewelry_shop.ClassXML
{
    [XmlRoot(ElementName = "SALE")]
    public class SaleXML
    {

        [XmlElement(ElementName = "sname")]
        public string SName { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "fname")]
        public string FName { get; set; }

        [XmlElement(ElementName = "saledate")]
        public string SaleDate { get; set; }

        [XmlElement(ElementName = "TitleName")]
        public string TitleName { get; set; } // вопрос

        [XmlElement(ElementName = "TitleType")]
        public string TitleType { get; set; } // вопрос


    }
}
