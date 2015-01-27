using System;
using System.Configuration;
using Castle.Windsor;
using Employee.Core.Views;

namespace Employee.Core.Config
{
    public class FileConfigProvider : IConfigProvider
    {
        private readonly IWindsorContainer _container;

        /// <summary>
        /// Конфигурация
        /// </summary>
        private AppConfig _config;

        public FileConfigProvider(IWindsorContainer container)
        {
            this._container = container;
        }

        public AppConfig GetConfig()
        {
            if (_config == null)
            {
                this._config = new AppConfig();

                var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = GetConfigFilePath() };
                var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                var pluginsSection = configuration.GetSection(PluginsSectionHandler.SectionName) as PluginsSectionHandler;

                if (pluginsSection != null && pluginsSection.Plugins != null)
                {
                    for (var i = 0; i < pluginsSection.Plugins.Count; i++)
                    {
                        var plugin = pluginsSection.Plugins[i];

                        _config.PluginsConfig.Add(plugin.Id, plugin.Enabled);
                    }
                }
            }

            return this._config;
        }

        private string GetConfigFilePath()
        {
            var appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            return System.IO.Path.Combine(appPath, "App.config"); ;
        }

        public void SaveConfig(AppConfig config)
        {
            throw new NotImplementedException();
        }
    }
}
