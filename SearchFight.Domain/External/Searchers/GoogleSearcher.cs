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
    public class GoogleSearcher : IGoogleSearcher
    {

        private readonly SearcherSettings _appSettings;
        private readonly HttpClient _httpClient;

        public GoogleSearcher(SearcherSettings appSettings)
        {
            _appSettings = appSettings;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Search> GetResults(string word)
        {
            await Task.Delay(6000);
            string uri = GetUri(word);

            using (var response = await _httpClient.GetAsync(uri))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Google Search Engine is not working ok. Try later");

                GoogleSearcherEntity result = JsonConvert.DeserializeObject<GoogleSearcherEntity>(await response.Content.ReadAsStringAsync());

                return new Search { searcher = _appSettings.Name, amountResults = long.Parse(result.searchInformation.totalResults), query = word };
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
