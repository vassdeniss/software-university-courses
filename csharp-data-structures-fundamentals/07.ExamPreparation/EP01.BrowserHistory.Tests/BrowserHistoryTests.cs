namespace EP01.BrowserHistory.Tests
{
    using EP01.BrowserHistory.Interfaces;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BrowserHistoryTests
    {
        private IHistory _browserHistory;
        private ILink _savedLink;
        private ILink _lastVisitedLink;
        private ILink _firstVisitedLink;

        [SetUp]
        public void Setup()
        {
            Random rnd = new Random();
            string[] websites = {
                "https://judge.softuni.bg/",
                "https://softuni.bg/",
                "https://www.quora.com/",
                "https://sli.do/event/",
                "https://www.youtube.com/watch?"
            };

            this._browserHistory = new BrowserHistory();
            for (int i = 0; i < 50; i++)
            {
                int firstDigit = rnd.Next(10);
                int secondDigit = rnd.Next(10);
                int thirdDigit = rnd.Next(10);
                int loadingTime = rnd.Next(3600);
                string randomUrl = $"{websites[rnd.Next(5)]}{firstDigit}{secondDigit}{thirdDigit}";

                var webLink = new Link(randomUrl, loadingTime);
                this._browserHistory.Open(webLink);

                if (i == 0)
                {
                    this._firstVisitedLink = webLink;
                }

                if (i == 13)
                {
                    this._savedLink = webLink;
                }

                if (i == 49)
                {
                    this._lastVisitedLink = webLink;
                }
            }
        }

        [Test]
        public void TestSizeReturnsCorrectNumber()
        {
            Assert.IsNotNull(this._browserHistory);
            Assert.AreEqual(50, this._browserHistory.Size);
        }

        [Test]
        public void TestOpenLinkWorksCorrectly()
        {
            Assert.IsNotNull(this._browserHistory);
            this._browserHistory.Open(new Link("test", 60));

            Assert.AreEqual(51, this._browserHistory.Size);
        }

        [Test]
        public void GetByUrlReturnsFirstLink()
        {
            var webLink = this._browserHistory.GetByUrl(this._savedLink.Url);

            Assert.IsNotNull(webLink);
            Assert.AreEqual(this._savedLink.Url, webLink.Url);
        }

        [Test]
        public void LastVisitedReturnsCorrectLink()
        {
            var lastVisitedLink = this._browserHistory.LastVisited();

            Assert.IsNotNull(lastVisitedLink);
            Assert.AreEqual(this._lastVisitedLink.Url, lastVisitedLink.Url);
        }

        [Test]
        public void DeleteFirstRemovesCorrectLink()
        {
            var removedLink = this._browserHistory.DeleteFirst();

            Assert.AreEqual(49, this._browserHistory.Size);
            Assert.AreEqual(this._firstVisitedLink.Url, removedLink.Url);
        }


        [Test]
        public void DeleteLastRemovesCorrectLink()
        {
            var removedLink = this._browserHistory.DeleteLast();

            Assert.AreEqual(49, this._browserHistory.Size);
            Assert.AreEqual(this._lastVisitedLink.Url, removedLink.Url);
        }

        [Test]
        public void RemoveLinksWorksCorrectly()
        {
            var history = new BrowserHistory();

            history.Open(new Link("https://www.youtube.com/watch?sdgdfdf", 100));
            history.Open(new Link("https://www.google.com/watch?sdgdfdf", 100));
            history.Open(new Link("https://www.youtube.com/watch?sdgdfdf", 100));
            history.Open(new Link("https://www.google.com/watch?sdgdfdf", 100));
            history.Open(new Link("https://www.youtube.com/watch?sdgdfdf", 100));
            history.Open(new Link("https://www.google.com/watch?sdgdfdf", 100));


            int actualCount = history.RemoveLinks("youtube");
            ILink[] actualLinks = history.ToArray();

            Assert.AreEqual(3, history.Size);
            Assert.AreEqual(3, actualCount);
            Assert.IsTrue(actualLinks.All(l => !l.Url.Contains("youtube")));
        }

        [Test]
        public void ContainsReturnsTrue()
        {
            Assert.IsTrue(this._browserHistory.Contains(this._firstVisitedLink));
        }

        [Test]
        public void ClearWorksCorrectly()
        {
            this._browserHistory.Clear();

            Assert.AreEqual(0, this._browserHistory.Size);
        }

        [Test]
        public void ToArrayWorksCorrectly()
        {
            ILink[] actual = this._browserHistory.ToArray();

            Assert.AreEqual(50, actual.Length);
            Assert.AreEqual(this._firstVisitedLink.Url, actual[actual.Length - 1].Url);
            Assert.AreEqual(this._lastVisitedLink.Url, actual[0].Url);
        }

        [Test]
        public void ToListWorksCorrectly()
        {
            List<ILink> actual = this._browserHistory.ToList();

            Assert.AreEqual(50, actual.Count);
            Assert.AreEqual(this._firstVisitedLink.Url, actual[actual.Count - 1].Url);
            Assert.AreEqual(this._lastVisitedLink.Url, actual[0].Url);
        }

        [Test]
        public void ViewHistoryWorksCorrectlyWithLink()
        {
            var history = new BrowserHistory();
            history.Open(new Link("https://www.youtube.com/watch?sdgdfdh", 50));
            history.Open(new Link("https://www.youtube.com/watch?sdgdfdt", 60));
            history.Open(new Link("https://www.youtube.com/watch?sdgdfds", 70));
            string expectedResult =
                "-- https://www.youtube.com/watch?sdgdfds 70s\r\n" +
                "-- https://www.youtube.com/watch?sdgdfdt 60s\r\n" +
                "-- https://www.youtube.com/watch?sdgdfdh 50s\r\n";

            string result = history.ViewHistory();

            Assert.AreEqual(expectedResult, result);
        }
    }
}
