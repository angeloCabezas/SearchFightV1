using SearchFight.Domain.Entities.Core;
using System.Collections.Generic;

namespace SearchFightV2.Helper
{
    public interface IConsoleDisplayFunctions
    {
        void ShowResults(Dictionary<string, SearchResults> Results);

        void ShowWinners(Dictionary<string, SearchResults> Results);

        void ShowFinalResult(Dictionary<string, SearchResults> Results);
    }
}
