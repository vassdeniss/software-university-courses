using System;
using System.Collections.Generic;

namespace L03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, IEnumerable<string> documents) : base(name)
        {
            Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; }

        public override string ToString()
        {
            return $"{base.ToString()}\n{string.Join(Environment.NewLine, Documents)}";
        }
    }
}
