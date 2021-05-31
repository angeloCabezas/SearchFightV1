using SearchFight.Domain.Entities.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFight.Domain.Contracts.Core
{
    public interface ISearchFunctions
    {
        Task<Dictionary<string, SearchResults>> ExecuteSeach(IEnumerable<string> args);

        void SaveInformation(Search result, ref Dictionary<string, SearchResults> Results);
    }
}
