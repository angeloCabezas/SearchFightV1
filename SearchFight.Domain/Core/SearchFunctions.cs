using SearchFight.Domain.Contracts.Core;
using SearchFight.Domain.Contracts.External.Searchers;
using SearchFight.Domain.Entities.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFight.Domain.Core
{
    public class SearchFunctions : ISearchFunctions
    {
        private readonly ISearcher[] _searchers;
        private readonly object balanceLock = new object();
        public SearchFunctions(params ISearcher[] searchers)
        {
            _searchers = searchers;
        }

        public async Task<Dictionary<string, SearchResults>> ExecuteSeach(IEnumerable<string> args)
        {
            Dictionary<string, SearchResults> results = new Dictionary<string, SearchResults>();

            var uploadTasks = new List<Task<Search>>();

            foreach (var item in args)
            {
                    foreach (ISearcher searcher in _searchers)
                    {
                        var uploadTask = Task.Run(() => searcher.GetResults(item).Result);
                        uploadTasks.Add(uploadTask);
                    }
            }

            IEnumerable<Search> res = await Task.WhenAll<Search>(uploadTasks);
            foreach (var itemResult in res) SaveInformation(itemResult,ref results);
          
            return results;
        }

        public void SaveInformation(Search result, ref Dictionary<string, SearchResults> Results)
        {
            lock (balanceLock)
            {
                if (!Results.ContainsKey(result.query))
                {
                    //Add a new Information
                    Results.Add(result.query, new SearchResults() { word = result.query, searches = new List<Search>() { result } });
                }
                else
                {
                    //Update Information
                    Results[result.query].searches.Add(result);
                }
            }
        }
    }
}
