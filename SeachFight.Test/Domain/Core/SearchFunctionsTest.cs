using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeachFight.Test.Domain.ExternalFake;
using SearchFight.Domain.Contracts.Core;
using SearchFight.Domain.Contracts.External.Searchers;
using SearchFight.Domain.Core;
using SearchFight.Domain.Entities.Core;
using System.Collections.Generic;

namespace SeachFight.Test.Domain.Core
{
    [TestClass]
    public class SearchFunctionsTest
    {
        public ISearchFunctions _searchFight;
        [TestInitialize]
        public void Initialize()
        {
            IGoogleSearcher fakeGoogleSearcher = new FakeGoogleSearcher();
            IBingSearcher fakeBingSearcher = new FakeBingSearcher();
            _searchFight = new SearchFunctions(fakeGoogleSearcher, fakeBingSearcher);
        }

        [TestMethod]
        public void ExecuteSeachTest()
        {
            //Arrange
            string[] args = new string[] { "test", "prueba" };

            //Act
            Dictionary<string, SearchResults> dictionary = _searchFight.ExecuteSeach(args).Result;
            var result = dictionary.ContainsKey(args[0]) && dictionary.ContainsKey(args[1]);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void SaveInformationTest()
        {
            // Arrange
            Search search = new Search() { searcher = "Searcher Test", amountResults = 1000, query = "test" };
            Dictionary<string, SearchResults> dictionary = new Dictionary<string, SearchResults>();

            //Act
            _searchFight.SaveInformation(search, ref dictionary);
            var result = dictionary.ContainsKey(search.query);

            //Assert
            Assert.AreEqual(true, result);
        }
    }
}
