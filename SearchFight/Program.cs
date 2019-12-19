using SearchFight.Application.Services.Searcher;
using SearchFight.AppSetting;
using SearchFight.Mapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using SearchFight.Application.Contracts.Services.Searchers;
using SearchFight.Application.Business;
using SearchFight.Application.Contracts.Business;
using SearchFight.Domain.DomainModel;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            //args = new string[] { ".net", "java", "ayuda prueba", "java", "JSON"};
            //Dependencies
            IGoogleSearcher googleSearcher = new GoogleSearcher(AppSettingsMapper.Map(new AppSettingsConsole()));
            IBingSearcher bingSearcher   = new BingSearcher(AppSettingsMapper.Map(new AppSettingsConsole()));

            //Get the results
            ISearchFunctions searchFunctions = new SearchFunctions(googleSearcher,bingSearcher);
            Dictionary<string, SearchResults> Results = searchFunctions.ExecuteSeach(args.Distinct()).Result;

            //Call to Console Functions for displaying information
            ConsoleDisplayFunctions consoleDisplayFunctions = new ConsoleDisplayFunctions();
            consoleDisplayFunctions.ShowResults(Results);
            consoleDisplayFunctions.ShowWinners(Results);
            consoleDisplayFunctions.ShowFinalResult(Results);
            Console.ReadLine();
        }

    }
}
