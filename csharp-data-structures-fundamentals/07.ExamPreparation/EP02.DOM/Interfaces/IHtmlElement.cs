namespace EP02.DOM.Interfaces
{
    using EP02.DOM.Models;
    using System.Collections.Generic;

    public interface IHtmlElement
    {
        ElementType Type { get; set; }

        IHtmlElement Parent { get; set; }

        List<IHtmlElement> Children { get; }

        Dictionary<string, string> Attributes { get; }
    }
}
