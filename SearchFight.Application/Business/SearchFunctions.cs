using SearchFight.Application.Contracts.Business;
using SearchFight.Application.Contracts.Services.Searchers;
using SearchFight.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Application.Business
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
            Dictionary<string, SearchResults> Results = new Dictionary<string, SearchResults>();

            foreach (var item in args)
            {
                for (int i = 0; i < _searchers.Length; i++)
                {
                    SaveInformation(await _searchers[i].GetResults(item), ref Results);
                }
            }

            return Results;
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
