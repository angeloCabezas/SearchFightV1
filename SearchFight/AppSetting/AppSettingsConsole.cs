using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.AppSetting
{
    public class AppSettingsConsole
    {
        public NameValueCollection searchEngines { get; set; }
        public NameValueCollection authorizationSearchEngines { get; set; }

        public AppSettingsConsole()
        {
            searchEngines = ConfigurationManager.GetSection("searchEngines") as NameValueCollection;
            authorizationSearchEngines = ConfigurationManager.GetSection("authorizationSearchEngines") as NameValueCollection;
        }
    }
}
