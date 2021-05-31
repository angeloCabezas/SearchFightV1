
namespace SearchFight.Domain.Entities.Core
{
    public class Search
    {
        public string query { get; set; }
        public string searcher { get; set; }
        public long amountResults { get; set; }
    }
}
