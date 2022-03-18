namespace EP01.BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EP01.BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private readonly LinkedList<ILink> links;

        public BrowserHistory() => links = new LinkedList<ILink>();

        public int Size => links.Count;

        public void Clear() => links.Clear();

        public bool Contains(ILink link) => links.Contains(link);

        public ILink DeleteFirst()
        {
            if (links.Count == 0)
            {
                throw new InvalidOperationException();
            }

            ILink link = links.Last.Value;
            links.RemoveLast();
            return link;
        }

        public ILink DeleteLast()
        {
            if (links.Count == 0)
            {
                throw new InvalidOperationException();
            }

            ILink link = links.First.Value;
            links.RemoveFirst();
            return link;
        }

        public ILink GetByUrl(string url)
        {
            LinkedListNode<ILink> node = links.First;

            while (node != null)
            {
                if (node.Value.Url == url)
                {
                    return node.Value;
                }

                node = node.Next;
            }

            return null;
        }

        public ILink LastVisited()
        {
            if (links.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return links.First.Value;
        }

        public void Open(ILink link) => links.AddFirst(link);

        public int RemoveLinks(string url)
        {
            url = url.ToLower();
            int count = 0;

            LinkedListNode<ILink> node = links.First;
            while (node != null)
            {
                LinkedListNode<ILink> newNode = node.Next;
                if (node.Value.Url.ToLower().Contains(url))
                {
                    links.Remove(node.Value);
                    count++;
                }

                node = newNode;
            }

            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            return count;
        }

        public ILink[] ToArray() => links.ToArray();

        public List<ILink> ToList() => links.ToList();

        public string ViewHistory()
        {
            if (links.Count == 0)
            {
                return "Browser history is empty!";
            }

            StringBuilder sb = new StringBuilder();

            foreach (ILink link in links)
            {
                sb.AppendLine(link.ToString());
            }

            return sb.ToString();
        }
    }
}
