using Newtonsoft.Json;
using SearchFight.Domain.Contracts.External.Searchers;
using SearchFight.Domain.Entities.Core;
using SearchFight.Domain.Entities.External;
using SearchFight.Domain.Entities.Settings;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight.Domain.External.Searchers
{
    public class BingSearcher : IBingSearcher
    {
        private readonly SearcherSettings _appSettings;
        private readonly HttpClient _httpClient;

        public BingSearcher(SearcherSettings appSettings)
        {
            _appSettings = appSettings;

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _appSettings.SubscriptionKey);

        }
        public async Task<Search> GetResults(string word)
        {
            await Task.Delay(10000);
            string uri = GetUri(word);
            using (var response = await _httpClient.GetAsync(uri))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Bing Search Engine is not working ok. Try later");

                BingSearcherEntity result = JsonConvert.DeserializeObject<BingSearcherEntity>(await response.Content.ReadAsStringAsync());

                return new Search { searcher = _appSettings.Name, amountResults = result.webPages.totalEstimatedMatches, query = word };
            }
        }

        public string GetUri(string word)
        {
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["q"] = word;

            string uri = _appSettings.Url + queryString;

            return uri;
        }
    }
}
