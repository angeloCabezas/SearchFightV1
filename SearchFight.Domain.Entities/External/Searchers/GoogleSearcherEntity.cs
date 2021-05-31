using System.Collections.Generic;

namespace SearchFight.Domain.Entities.External
{
    public class GoogleSearcherEntity
    {
        public string kind { get; set; }
        public Url url { get; set; }
        public Queries queries { get; set; }
        public SearchInformation searchInformation { get; set; }
    }

    public class Url
    {
        public string type { get; set; }
        public string template { get; set; }
    }

    public class Request
    {
        public int count { get; set; }
        public int startIndex { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
    }

    public class Queries
    {
        public List<Request> request { get; set; }
    }

    public class SearchInformation
    {
        public double searchTime { get; set; }
        public string formattedSearchTime { get; set; }
        public string totalResults { get; set; }
        public string formattedTotalResults { get; set; }
    }
}
