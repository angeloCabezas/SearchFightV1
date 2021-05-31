using SearchFight.Domain.Contracts.External.Searchers;
using SearchFight.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeachFight.Test.Domain.ExternalFake
{
    class FakeBingSearcher : IBingSearcher
    {
        public Task<Search> GetResults(string word)
        {
            var searchFake = new Search { searcher = "Bing", amountResults = 150, query = word };
            return Task.FromResult<Search>(searchFake);
        }

        public string GetUri(string word)
        {
            throw new NotImplementedException();
        }
    }
}
