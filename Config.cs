using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WordBlacklist
{

    public class Config : IRocketPluginConfiguration

    {
        [XmlArrayItem(ElementName = "word")]
        public List<WordBlacklist> Restricted;

        public bool IgnoreAdmins;

        public void LoadDefaults()
        {
            Restricted = new List<WordBlacklist>
            {
                new WordBlacklist { name = "CreatedByMQS" },
            };

            IgnoreAdmins = true;


        }
    }
}


