using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jewelry_shop.ClassXML
{
    [XmlRoot(ElementName = "MATERIAL")]
    public class MaterialXML
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "gramprice")]
        public string GramPrice { get; set; }

        [XmlElement(ElementName = "TITLE")]
        public List<TitleXML> TITLE { get; set; }
    }
}
