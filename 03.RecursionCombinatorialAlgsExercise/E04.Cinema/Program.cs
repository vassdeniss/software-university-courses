using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E04.Cinema
{
    internal class Program
    {
        static List<string> _names;
        static string[] _positions;
        static bool[] _locked;

        static void Main(string[] args)
        {
            _names = Console.ReadLine().Split(", ").ToList();
            _positions = new string[_names.Count];
            _locked = new bool[_names.Count];

            string input = Console.ReadLine();
            while (input != "generate")
            {
                string[] data = input.Split(" - ");
                string name = data[0];
                int place = int.Parse(data[1]) - 1;

                _positions[place] = name;
                _locked[place] = true;
                _names.Remove(name);

                input = Console.ReadLine();
            }

            Permute(0);
        }

        private static void Permute(int ind)
        {
            if (ind >= _names.Count)
            {
                Print();
                return;
            }

            Permute(ind + 1);

            for (int i = ind + 1; i < _names.Count; i++)
            {
                Swap(ind, i);
                Permute(ind + 1);
                Swap(ind, i);
            }
        }

        private static void Print()
        {
            int ind = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _positions.Length; i++)
            {
                if (_locked[i]) sb.Append($"{_positions[i]} ");
                else sb.Append($"{_names[ind++]} ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        private static void Swap(int first, int second) =>
            (_names[first], _names[second]) = (_names[second], _names[first]);
    }
}
