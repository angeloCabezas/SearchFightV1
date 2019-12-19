
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace SearchFight.Domain.AppSetting
{
    public interface IAppSettings
    {
        NameValueCollection searchEngines { set; get; }
        NameValueCollection authorizationSearchEngines { get; set; }
    }
}