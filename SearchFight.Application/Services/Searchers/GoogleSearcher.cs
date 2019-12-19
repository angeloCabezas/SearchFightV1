using SearchFight.Domain.AppSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchFight.Application.Config;
using SearchFight.Domain.DomainModelExtern;
using System.Net.Http;
using Newtonsoft.Json;
using SearchFight.Application.Contracts.Services.Searchers;
using SearchFight.Domain.DomainModel;

namespace SearchFight.Application.Services.Searcher
{
    public class GoogleSearcher : IGoogleSearcher
    {
        private readonly IAppSettings _appSettings;
        private readonly IAppConfig _appConfig;
        private readonly HttpClient _httpClient;
        private string searcherName = "Google";

        public GoogleSearcher(IAppSettings appSettings)
        {
            _appSettings = appSettings;
            _appConfig = new AppConfig(appSettings, searcherName);

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Search> GetResults(string word)
        {
            string uri = GetUri(word);

            using (var response = await _httpClient.GetAsync(uri))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Google Search Engine is not working ok. Try later");

                GoogleSearcherEntity result = JsonConvert.DeserializeObject<GoogleSearcherEntity>(await response.Content.ReadAsStringAsync());

                return new Search { searcher = searcherName, amountResults = long.Parse(result.searchInformation.totalResults), query = word };
            }
        }

        public string GetUri(string word)
        {
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["q"] = word;

            string uri = _appConfig.ServiceUrl() + queryString;

            return uri;
        }
    }
}
