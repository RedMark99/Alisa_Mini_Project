using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jewelry_shop.ClassXML
{
    [XmlRoot(ElementName = "MATERIALS")]
    public class MATERIALS
    {
        [XmlElement(ElementName = "MATERIAL")]
        public List<MaterialXML> MATERIAL { get; set; }
    }
}
