using System;
using System.Text;

namespace E07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            int power = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == '>')
                {
                    power += (int)char.GetNumericValue(sb[i + 1]);

                    while (power > 0)
                    {
                        int index = i + 1;
                        if (index >= sb.Length) break;

                        if (sb[index] != '>')
                        {
                            sb.Remove(index, 1);
                            power--;
                        }
                        else if (sb[index] == '>') break;
                    }
                }
            }

            Console.WriteLine(sb);
        }
    }
}
