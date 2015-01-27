namespace Employee.Core.Config
{
    public interface IConfigProvider
    {
        /// <summary>
        /// Загрузка конфигурации.
        /// </summary>
        /// <returns>
        /// Возвращает экземпляр <see cref="AppConfig"/>
        /// </returns>
        AppConfig GetConfig();

        /// <summary>
        /// Сохранение конфигурации.
        /// </summary>
        /// <param name="config">
        /// Сохраняемая конфигурация.
        /// </param>
        void SaveConfig(AppConfig config);
    }
}
