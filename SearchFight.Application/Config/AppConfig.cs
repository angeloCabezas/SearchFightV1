using SearchFight.Domain.AppSetting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Application.Config
{
    public class AppConfig : IAppConfig
    {
        private readonly IAppSettings _configurationManager;
        private readonly string _searcher;

        public AppConfig(IAppSettings configurationManager, string searcher)
        {
            _configurationManager = configurationManager;
            _searcher = searcher;
        }

        public string ServiceUrl()
        {
            return _configurationManager.searchEngines.GetValues(_searcher)[0].ToString();
        }

        public string GetOcpApimSubscriptionKey()
        {
            return _configurationManager.authorizationSearchEngines.GetValues(_searcher)[0].ToString();
        }

        

    }
}
