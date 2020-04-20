using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jewelry_shop.ClassXML
{

    [XmlRoot(ElementName = "TITLE")]
    public class TitleXML
    {
        [XmlElement(ElementName = "titleid")]
        public string Titleid { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "PRODUCT")]
        public List<ProductXML> PRODUCT { get; set; }

        [XmlElement(ElementName = "SALE")]
        public List<SaleXML> SALE { get; set; }
    }
}
