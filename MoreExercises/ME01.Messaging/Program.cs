using System;
using System.Collections.Generic;
using System.Linq;

namespace ME01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numList = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            List<char> messageList = new List<char>();
            messageList.AddRange(Console.ReadLine());

            string result = string.Empty;
            foreach (int n in numList)
            {
                int sum = 0;
                int number = n;
                while (number > 0)
                {
                    sum += number % 10;
                    number /= 10;
                }

                try
                {
                    result += messageList[sum];
                    messageList.RemoveAt(sum);
                }
                catch (Exception)
                {
                    int toCount = sum - messageList.Count;
                    result += messageList[0 + toCount];
                    messageList.RemoveAt(0 + toCount);
                }
            }

            Console.WriteLine(result);
        }
    }
}
