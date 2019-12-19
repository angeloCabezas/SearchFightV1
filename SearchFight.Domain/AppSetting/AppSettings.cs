using SearchFight.Domain.AppSetting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Domain.AppSetting
{
    public class AppSettings : IAppSettings
    {
        public NameValueCollection searchEngines { get; set ; }
        public NameValueCollection authorizationSearchEngines { get; set; }
    }
}
