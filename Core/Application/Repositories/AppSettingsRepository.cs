using Domain.Master;

namespace Application.Repositories
{
    public interface IAppSettingsRepository
    {
        public List<AppSetting> GetAppSettings();
        public AppSetting GetAppSettingById(Guid id);
        public Guid CreateAppSetting(AppSetting setting);
        public Guid UpdateAppSetting(AppSetting setting);
        public Guid DeleteAppSetting(Guid appSettingId);
    }

    public class AppSettingsRepository : IAppSettingsRepository
    {
        private List<AppSetting> _appSettings { get; set; }

        public AppSettingsRepository()
        {
            _appSettings = new List<AppSetting>();
        }

        public Guid CreateAppSetting(AppSetting setting)
        {
            setting.Id = Guid.NewGuid();
            _appSettings.Add(setting);

            return setting.Id;
        }

        public Guid DeleteAppSetting(Guid appSettingId)
        {
            _appSettings.RemoveAt(_appSettings.FindIndex(a => a.Id == appSettingId));

            return appSettingId;
        }

        public List<AppSetting> GetAppSettings()
        {
            return _appSettings;
        }

        public Guid UpdateAppSetting(AppSetting setting)
        {
            var existingAppSetting = _appSettings.Find(a => a.Id == setting.Id);

            if (existingAppSetting != null)
            {
                existingAppSetting.ReferenceKey = setting.ReferenceKey;
                existingAppSetting.Value= setting.Value;
                existingAppSetting.Description = setting.Description;
                existingAppSetting.Type= setting.Type;
            }

            return setting.Id;
        }

        public AppSetting GetAppSettingById(Guid id)
        {
            return _appSettings.Find(a => a.Id == id)!;
        }
    }
}
