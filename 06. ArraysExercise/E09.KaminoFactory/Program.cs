using System;
using System.Linq;

namespace E10.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int[] dnaArray = new int[arrayLength]; // Best DNA array

            int dnaSum = 0; // Best sum of ones
            int dnaCount = -1; // Best total number of ones
            int dnaStartIndex = -1; // Best (leftmost) start index
            int dnaSamples = 0; // The number of the best checked DNA array

            int sample = 0;
            while (input != "Clone them!")
            {
                // Part I - Work on the current DNA array

                sample++;
                // Current DNA to check
                int[] currDna = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currCount = 0; // Current highest number of ones
                int currStartIndex = 0; // The current start index of the sequence of ones
                int currEndIndex = 0; // The current end index of the sequence of ones
                int currDnaSum = 0; // Current sum of the sequence of ones
                bool isBetterDNA = false; // Is this the best dna of all?

                int count = 0;
                // Loop through the current array
                for (int i = 0; i < currDna.Length; i++)
                {
                    // If you find a zero skip it over
                    // and reverse current count back to zero
                    // Else count one up
                    if (currDna[i] != 1)
                    {
                        count = 0; continue;
                    }

                    // if the current count is higher than the highest
                    // record the new highest count of ones
                    // also register the current end index of the sequence
                    count++;
                    if (count > currCount) {
                        currCount = count;
                        currEndIndex = i;
                    }
                }

                // Find the start index of the sequence by subtracting the total
                // sequence count and adding an 1 cause it's an array duh
                currStartIndex = currEndIndex - currCount + 1;
                currDnaSum = currDna.Sum();
                // * Sum returns the sum of all the array numbers
                // * It is an array of ones and zeros so sum works perfectly here

                // Part II - Check if this DNA is better than the already best DNA

                // Case - longest subsequence of ones
                if (currCount > dnaCount)
                {
                    isBetterDNA = true;

                }
                else if (currCount == dnaCount)
                {
                    // Case - ;eftmost starting index
                    if (currStartIndex < dnaStartIndex)
                    {
                        isBetterDNA = true;
                    }
                    else if (currStartIndex == dnaStartIndex)
                    {
                        // Case - greatest sum
                        if (currDnaSum > dnaSum)
                        {
                            isBetterDNA = true;
                        }
                    }
                }

                // Part III - Overwrite best dna array

                if (isBetterDNA)
                {
                    dnaArray = currDna;
                    dnaCount = currCount;
                    dnaStartIndex = currStartIndex;
                    dnaSum = currDnaSum;
                    dnaSamples = sample;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {dnaSamples} with sum: {dnaSum}.");
            Console.WriteLine(string.Join(" ", dnaArray));
        }
    }
}
