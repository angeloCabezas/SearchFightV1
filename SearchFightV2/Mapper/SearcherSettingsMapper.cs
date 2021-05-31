using SearchFight.Domain.Entities.Settings;
using SearchFightV2.AppSettings;

namespace SearchFightV2.Mapper
{
    public static class SearcherSettingsMapper
    {
        public static SearcherSettings Map(Searcher searcher)
        {
            return new SearcherSettings()
            {
                Name = searcher.Name,
                Url = searcher.Url,
                SubscriptionKey = searcher.SubscriptionKey
            };
        }
    }
}
