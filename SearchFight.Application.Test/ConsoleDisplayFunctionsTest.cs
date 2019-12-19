using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFight.Application.Business;
using SearchFight.Application.Contracts.Business;
using SearchFight.Domain.DomainModel;

namespace SearchFight.Application.Test
{
    [TestClass]
    public class ConsoleDisplayFunctionsTest
    {
        public IConsoleDisplayFunctions _consoleDisplayFunctions;
        public Dictionary<string, SearchResults> _fakeResults;

        [TestInitialize]
        public void Initialize()
        {
            _consoleDisplayFunctions = new ConsoleDisplayFunctions();

            //Arrange
            _fakeResults = new Dictionary<string, SearchResults>();
            Search search1 = new Search() { query = ".net", searcher = "Google", amountResults = 100 };
            Search search2 = new Search() { query = ".net", searcher = "Bing", amountResults = 200 };
            _fakeResults.Add(".net",new SearchResults() { word = ".net", searches = new List<Search>() { search1 } });
            _fakeResults[".net"].searches.Add(search2);
        }

        [TestMethod]
        public void ConsoleWriteMessageTest()
        {
            //Act
            StringBuilder builder = new StringBuilder();
            using (TextWriter result = new StringWriter(builder))
            {
                Console.SetOut(result);
                _consoleDisplayFunctions.ShowResults(_fakeResults);

                //Assert
                Assert.AreEqual(".net: Bing: 200 Google: 100", builder.ToString().Trim());
            }
        }

        [TestMethod]
        public void ShowWinnersTest()
        {
            //Act
            StringBuilder builder = new StringBuilder();
            using (TextWriter result = new StringWriter(builder))
            {
                Console.SetOut(result);
                _consoleDisplayFunctions.ShowWinners(_fakeResults);

                //Assert
                Assert.AreEqual("Bing winner: .net", builder.ToString().Trim());
            }
        }

        [TestMethod]
        public void ShowFinalResultTest()
        {
            //Act
            StringBuilder builder = new StringBuilder();
            using (TextWriter result = new StringWriter(builder))
            {
                Console.SetOut(result);
                _consoleDisplayFunctions.ShowFinalResult(_fakeResults);

                //Assert
                Assert.AreEqual("Total winner: .net", builder.ToString().Trim());
            }
        }

    }
}
