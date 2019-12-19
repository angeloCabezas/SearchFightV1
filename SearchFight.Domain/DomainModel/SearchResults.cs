using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Domain.DomainModel
{
    public class SearchResults
    {
        public string word { get; set; }
        public List<Search> searches { get; set; }
        public Search winner { get => searches.OrderByDescending(x => x.amountResults).FirstOrDefault(); }
    }
}
