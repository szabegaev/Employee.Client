using System.Configuration;

namespace Employee.Core.Config
{
    public class PluginsSectionHandler : ConfigurationSection
    {
        public static readonly string SectionName = "plugins";

        private static readonly ConfigurationProperty 
            propPluginsSection = new ConfigurationProperty(null, typeof(PluginsSection), null, ConfigurationPropertyOptions.IsDefaultCollection);

        private static ConfigurationPropertyCollection properties = new ConfigurationPropertyCollection();
        static PluginsSectionHandler()
        {
            properties.Add(propPluginsSection);
        }

        /// <summary>
        /// Возвращает коллекцию элементов конфигурации модулей.
        /// </summary>
        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public PluginsSection Plugins
        {
            get
            {
                return (PluginsSection)base[propPluginsSection];
            }
        }
    }
}
