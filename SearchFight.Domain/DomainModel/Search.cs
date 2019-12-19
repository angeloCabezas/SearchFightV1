using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Domain.DomainModel
{
    public class Search
    {
        public string query { get; set; }
        public string searcher { get; set; }
        public long amountResults { get; set; }
    }
}
