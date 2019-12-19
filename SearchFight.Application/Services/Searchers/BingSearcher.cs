using SearchFight.Domain.AppSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SearchFight.Application.Config;
using Newtonsoft.Json;
using SearchFight.Domain.DomainModelExtern;
using SearchFight.Application.Contracts.Services.Searchers;
using SearchFight.Domain.DomainModel;

namespace SearchFight.Application.Services.Searcher
{
    public class BingSearcher : IBingSearcher
    {
        private readonly IAppSettings _appSettings;
        private readonly IAppConfig _appConfig;
        private readonly HttpClient _httpClient;
        private string searcherName = "Bing";

        public BingSearcher(IAppSettings appSettings)
        {
            _appSettings = appSettings;
            _appConfig = new AppConfig(appSettings, searcherName);

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _appConfig.GetOcpApimSubscriptionKey());
            
        }

        public async Task<Search> GetResults(string word)
        {
            string uri = GetUri(word);
            using (var response = await _httpClient.GetAsync(uri))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Bing Search Engine is not working ok. Try later");

                BingSearcherEntity result = JsonConvert.DeserializeObject<BingSearcherEntity>(await response.Content.ReadAsStringAsync());

                return new Search { searcher = searcherName, amountResults = result.webPages.totalEstimatedMatches, query = word };
            }
        }

        public string GetUri(string word) {
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["q"] = word;

            string uri = _appConfig.ServiceUrl() + queryString;

            return uri;
        }
    }
}
