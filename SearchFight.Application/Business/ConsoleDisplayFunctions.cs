using SearchFight.Application.Contracts.Business;
using SearchFight.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Application.Business
{
    public class ConsoleDisplayFunctions : IConsoleDisplayFunctions
    {
        public void ShowResults(Dictionary<string, SearchResults> Results)
        {
            foreach (KeyValuePair<string, SearchResults> keyValuePair in Results)
            {
                Console.Write("{0}:", keyValuePair.Key);

                foreach (Search item in keyValuePair.Value.searches.OrderBy(x => x.searcher))
                {
                    Console.Write(" {0}: {1}", item.searcher, item.amountResults);
                }
                Console.WriteLine();
            }
        }

        public void ShowWinners(Dictionary<string, SearchResults> Results)
        {
            foreach (KeyValuePair<string, SearchResults> keyValuePair in Results)
            {
                Console.WriteLine("{0} winner: {1}", keyValuePair.Value.winner.searcher, keyValuePair.Key);
            }
        }
        public void ShowFinalResult(Dictionary<string, SearchResults> Results)
        {
            if (Results.Count > 0)
            {
                SearchResults results = Results.Values.OrderByDescending(x => x.winner.amountResults).FirstOrDefault();
                Console.WriteLine("Total winner: {0}", results.word);
            }
        }


    }
}
