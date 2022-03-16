namespace Logger.Layouts
{
    public class XmlLayout : Layout
    {
        private const string XmlFormat = 
@"<log>
    <date>{0}</date>
    <level>{1}</level>
    <message>{2}</message>
</log>
";

        public XmlLayout() : base(XmlFormat) { }
    }
}
