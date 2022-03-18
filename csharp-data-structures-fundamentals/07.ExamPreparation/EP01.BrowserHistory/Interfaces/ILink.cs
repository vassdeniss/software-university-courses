namespace EP01.BrowserHistory.Interfaces
{
    public interface ILink
    {
        string Url { get; set; }

        int LoadingTime { get; set; }
    }
}
