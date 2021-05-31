using System.Collections.Generic;
using System.Linq;

namespace SearchFight.Domain.Entities.Core
{
    public class SearchResults
    {
        public string word { get; set; }
        public List<Search> searches { get; set; }
        public Search winner { get => searches.OrderByDescending(x => x.amountResults).FirstOrDefault(); }
    }
}
