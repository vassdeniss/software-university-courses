namespace EP01.BrowserHistory
{
    using EP01.BrowserHistory.Interfaces;

    public class Link : ILink
    {
        public Link(string url, int loadingTime)
        {
            Url = url;
            LoadingTime = loadingTime;
        }

        public string Url { get; set; }
        public int LoadingTime { get; set; }

        public override string ToString()
        {
            return $"-- {Url} {LoadingTime}s";
        }
    }
}
