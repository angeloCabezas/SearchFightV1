using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchFight.Domain.DomainModel;

namespace SearchFight.Application.Contracts.Services.Searchers
{
    public interface ISearcher
    {
        Task<Search> GetResults(string word);

        string GetUri(string word);
    }
}
