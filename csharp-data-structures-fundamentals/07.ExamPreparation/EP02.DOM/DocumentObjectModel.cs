namespace EP02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EP02.DOM.Interfaces;
    using EP02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root) => Root = root;

        public DocumentObjectModel() => Root = new HtmlElement(ElementType.Document, new HtmlElement(ElementType.Html, new HtmlElement(ElementType.Head), new HtmlElement(ElementType.Body)));

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

            queue.Enqueue(Root);
            while (queue.Count != 0)
            {
                IHtmlElement curr = queue.Dequeue();

                if (curr.Type == type) return curr;

                foreach (IHtmlElement child in curr.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            List<IHtmlElement> list = new List<IHtmlElement>();
            DFS(Root, type, list);
            return list;
        }

        private void DFS(IHtmlElement node, ElementType type, List<IHtmlElement> list)
        {
            foreach (IHtmlElement child in node.Children)
            {
                DFS(child, type, list);
            }

            if (node.Type == type)
            {
                list.Add(node);
            }
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            return FindElement(htmlElement) != null;
        }

        private IHtmlElement FindElement(IHtmlElement htmlElement)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

            queue.Enqueue(Root);
            while (queue.Count != 0)
            {
                IHtmlElement curr = queue.Dequeue();

                if (curr == htmlElement) return curr;

                foreach (IHtmlElement child in curr.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            ValidateElement(parent);
            parent.Children.Insert(0, child);
            child.Parent = parent;
        }

        private void ValidateElement(IHtmlElement parent)
        {
            if (!Contains(parent))
            {
                throw new InvalidOperationException();
            }
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            ValidateElement(parent);
            parent.Children.Add(child);
            child.Parent = parent;
        }

        public void Remove(IHtmlElement htmlElement)
        {
            ValidateElement(htmlElement);
            htmlElement.Parent.Children.Remove(htmlElement);
            htmlElement.Parent = null;
            htmlElement.Children.Clear();
        }

        public void RemoveAll(ElementType elementType)
        {
            List<IHtmlElement> list = GetElementsByType(elementType);
            list.ForEach(x => Remove(x));
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            ValidateElement(htmlElement);

            if (!htmlElement.Attributes.ContainsKey(attrKey))
            {
                htmlElement.Attributes.Add(attrKey, attrValue);
                return true;
            }

            return false;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            ValidateElement(htmlElement);

            if (htmlElement.Attributes.ContainsKey(attrKey))
            {
                htmlElement.Attributes.Remove(attrKey);
                return true;
            }

            return false;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

            queue.Enqueue(Root);
            while (queue.Count != 0)
            {
                IHtmlElement curr = queue.Dequeue();

                if (curr.Attributes.ContainsKey("id"))
                {
                    if (curr.Attributes["id"] == idValue)
                    {
                        return curr;
                    }
                }

                foreach (IHtmlElement child in curr.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            DFSString(Root, 0, sb);
            return sb.ToString();
        }

        private void DFSString(IHtmlElement node, int indent, StringBuilder sb)
        {
            sb.Append(' ', indent).AppendLine(node.Type.ToString());

            foreach (IHtmlElement child in node.Children)
            {
                DFSString(child, indent + 2, sb);
            }
        }
    }
}
