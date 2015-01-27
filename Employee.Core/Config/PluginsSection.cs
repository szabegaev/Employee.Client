using System.Configuration;

namespace Employee.Core.Config
{
    [ConfigurationCollection(typeof(PluginConfig), AddItemName = "plugin", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class PluginsSection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PluginConfig();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PluginConfig)element).Id;
        }

        /// <summary>
        /// Индексатор коллекции.
        /// </summary>
        /// <param name="index"></param>
        public PluginConfig this[int index]
        {
            get { return (PluginConfig)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
    }
}
