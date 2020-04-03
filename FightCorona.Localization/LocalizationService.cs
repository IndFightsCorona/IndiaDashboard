using FightCorona.Localization.Resources.Countries;
using FightCorona.Localization.Resources.Dashboard;
using FightCorona.Localization.Resources.States;
using FightCorona.Models;

namespace FightCorona.Localization
{
    public static class LocalizationService
    {
        public static string GetText(ResourceCategory resourceCategory, string key)
        {
            switch (resourceCategory)
            {
                case ResourceCategory.Dashboard:
                    return Dashboard.ResourceManager.GetString(key);
                case ResourceCategory.Countries:
                    return Countries.ResourceManager.GetString(key);
                case ResourceCategory.States:
                    return States.ResourceManager.GetString(key);
                default:
                    return string.Empty;
            }
        }
    }
}
