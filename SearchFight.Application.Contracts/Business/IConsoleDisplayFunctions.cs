using SearchFight.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Application.Contracts.Business
{
    public interface IConsoleDisplayFunctions
    {
        void ShowResults(Dictionary<string, SearchResults> Results);

        void ShowWinners(Dictionary<string, SearchResults> Results);

        void ShowFinalResult(Dictionary<string, SearchResults> Results);
    }
}
