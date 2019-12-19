using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Domain.DomainModelExtern
{
    public class BingSearcherEntity
    {
        public string _type { get; set; }
        public Instrumentation instrumentation { get; set; }
        public WebPages webPages { get; set; }
    }

    public class Instrumentation
    {
        public string pingUrlBase { get; set; }
        public string pageLoadPingUrl { get; set; }
    }

    public class WebPages
    {
        public string webSearchUrl { get; set; }
        public string webSearchUrlPingSuffix { get; set; }
        public int totalEstimatedMatches { get; set; }
    }

}
