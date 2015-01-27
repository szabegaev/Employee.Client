using System.Configuration;

namespace Employee.Core.Config
{
    public class PluginConfig : ConfigurationElement
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [ConfigurationProperty("id", IsKey = true, IsRequired = true)]
        public string Id
        {
            get
            {
                return (string)this["id"];
            }

            set
            {
                this["id"] = value;
            }
        }

        [ConfigurationProperty("enabled")]
        public string Enabled
        {
            get
            {
                return this["enabled"].ToString();
            }

            set
            {
                this["enabled"] = value;
            }
        }
    }
}
