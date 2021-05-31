using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using SearchFight.Domain.Contracts.Core;
using SearchFight.Domain.Contracts.External.Searchers;
using SearchFight.Domain.Core;
using SearchFight.Domain.Entities.Core;
using SearchFight.Domain.External.Searchers;
using SearchFightV2.AppSettings;
using SearchFightV2.Mapper;
using System.Linq;
using SearchFightV2.Helper;
using System.Threading.Tasks;

namespace SearchFightV2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*Setting up*/
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);
            var configuration = builder.Build();

            /*Get Settings for APIs*/
            var bingSettings = new Searcher();
            configuration.GetSection("Searchers:Bing").Bind(bingSettings);

            var googleSettings = new Searcher();
            configuration.GetSection("Searchers:Google").Bind(googleSettings);

            /*Get Settings for APIs*/
            List<ISearcher> SearcherList = new List<ISearcher>();
            if (bingSettings.Active == 1)  SearcherList.Add(new BingSearcher(SearcherSettingsMapper.Map(bingSettings)));
            if (googleSettings.Active == 1) SearcherList.Add(new GoogleSearcher(SearcherSettingsMapper.Map(googleSettings)));

            /*Values to Search*/
            args = new string[] { "java", "ayuda", "java", "JSON"};


            Console.WriteLine("Searching .....");
            ISearchFunctions searchFunctions = new SearchFunctions(SearcherList.ToArray());
            Dictionary<string, SearchResults> results = searchFunctions.ExecuteSeach(args.Distinct()).Result;
            Console.WriteLine("Searching Done");
            DisplayResults(results);
            Console.ReadLine();
        }

        static void DisplayResults(Dictionary<string, SearchResults> results) {
            Console.WriteLine("Printing ...."); 
            Console.WriteLine("====================================");
            ConsoleDisplayFunctions consoleDisplayFunctions = new ConsoleDisplayFunctions();
            consoleDisplayFunctions.ShowResults(results); 
            Console.WriteLine("====================================");
            consoleDisplayFunctions.ShowWinners(results); 
            Console.WriteLine("====================================");
            consoleDisplayFunctions.ShowFinalResult(results);
        }

        static void BuildConfig(IConfigurationBuilder builder) {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }
    }
}
