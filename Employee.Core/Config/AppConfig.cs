using System.Collections.Generic;

namespace Employee.Core.Config
{
    public class AppConfig
    {
        private IDictionary<string, object> _appSettings;
        private IDictionary<string, string> _enabledPlugins;
        
        /// <summary>
        /// Создает экземпляр класса <see cref="AppConfig"/>.
        /// </summary>
        public AppConfig()
        {
        }

        /// <summary>
        /// Настройки приложения.
        /// </summary>
        public IDictionary<string, object> AppSettings
        {
            get { return _appSettings ?? (_appSettings = new Dictionary<string, object>()); }
        }

        /// <summary>
        /// Подключенные плагины.
        /// </summary>
        public IDictionary<string, string> PluginsConfig
        {
            get { return _enabledPlugins ?? (_enabledPlugins = new Dictionary<string, string>()); }
        }
    }
}
