using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchFight.AppSetting;
using SearchFight.Domain.AppSetting;

namespace SearchFight.Mapper
{
    public static class AppSettingsMapper
    {
        public static IAppSettings Map(AppSettingsConsole appSettingsConsole) {

            return new AppSettings() { 
                searchEngines = appSettingsConsole.searchEngines, 
                authorizationSearchEngines = appSettingsConsole.authorizationSearchEngines
            };
        }
    }
}
