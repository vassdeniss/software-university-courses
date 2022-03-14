using System.Collections.Generic;

namespace L03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IEnumerable<string> documents = new List<string>() { "importantDocumentOne", "importantDocumentTwo" };
            IEnumerable<IEmployee> list = new List<IEmployee>() { new Manager("Garsia", documents), new Supervisor("John", true) };
            DetailsPrinter printer = new DetailsPrinter(list);
            printer.PrintDetails();
        }
    }
}
