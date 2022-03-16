namespace Logger.Layouts
{
    public class SimpleLayout : Layout
    {
        private const string SimpleFormat = "{0} - {1} - {2}";

        public SimpleLayout() : base(SimpleFormat) { }
    }
}
