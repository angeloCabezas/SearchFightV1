using SearchFight.Domain.Entities.Core;
using System.Threading.Tasks;

namespace SearchFight.Domain.Contracts.External.Searchers
{
    public interface ISearcher
    {
        Task<Search> GetResults(string word);
        string GetUri(string word);
    }
}
