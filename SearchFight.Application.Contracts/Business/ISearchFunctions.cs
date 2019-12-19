using SearchFight.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Application.Contracts.Business
{
    public interface ISearchFunctions
    {
        Task<Dictionary<string, SearchResults>> ExecuteSeach(IEnumerable<string> args);
        void SaveInformation(Search result, ref Dictionary<string, SearchResults> Results);
    }
}
