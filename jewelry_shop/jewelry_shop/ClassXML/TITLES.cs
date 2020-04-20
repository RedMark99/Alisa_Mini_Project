    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jewelry_shop.ClassXML
{
    [XmlRoot(ElementName = "TITLES")]
    public class TITLES
    {
        [XmlElement(ElementName = "TITLE")]
        public List<TitleXML> TITLE { get; set; }
    }
}
