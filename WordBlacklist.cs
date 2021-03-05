using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WordBlacklist
{
    public class WordBlacklist
    {
        [XmlAttribute("name")]
        public string name;


        public WordBlacklist()
        {
            name = "";
        }

        public WordBlacklist(string name)
        {
            this.name = name;
        }
    }
}