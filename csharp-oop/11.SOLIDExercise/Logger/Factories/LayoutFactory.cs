using Logger.Layouts;
using System;

namespace Logger.Factories
{
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            return type switch
            {
                "SimpleLayout" => new SimpleLayout(),
                "XmlLayout" => new XmlLayout(),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
