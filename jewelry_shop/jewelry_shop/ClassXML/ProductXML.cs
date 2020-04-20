using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jewelry_shop.ClassXML
{
    [XmlRoot(ElementName = "PRODUCT")]
    public class ProductXML
    {
        [XmlElement(ElementName = "materialname")]
        public string materialname { get; set; }

        [XmlElement(ElementName = "titlename")]
        public string titlename { get; set; }

        [XmlElement(ElementName = "titletype")]
        public string titletype { get; set; }

        [XmlElement(ElementName = "weight")]
        public string Weight { get; set; }
        [XmlElement(ElementName = "price")]
        public string Price { get; set; }
    }
}
