namespace EP02.DOM.Models
{
    using System.Collections.Generic;
    using EP02.DOM.Interfaces;

    public class HtmlElement : IHtmlElement
    {
        public HtmlElement(ElementType type, params IHtmlElement[] children)
        {
            Type = type;
            Attributes = new Dictionary<string, string>();
            Children = new List<IHtmlElement>();

            foreach (IHtmlElement child in children)
            {
                Children.Add(child);
                child.Parent = this;
            }
        }

        public ElementType Type { get; set; }

        public IHtmlElement Parent { get; set; }

        public List<IHtmlElement> Children { get; }

        public Dictionary<string, string> Attributes { get; }
    }
}
