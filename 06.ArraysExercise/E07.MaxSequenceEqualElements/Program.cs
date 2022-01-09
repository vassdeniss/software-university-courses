using System;
using System.Linq;

namespace E07.MaxSequenceEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool isFirstSequence = false;

            int sequenceNumber = -1;
            int sequenceNumberTimesSeen = 1;

            int firstSequenceNumber = -1;
            int firstSequenceNumberTimesSeen = -1;

            int bestSequenceNumber = -1;
            int bestSequenceNumberTimesSeen = -1;

            int firstArrayNumber = inputArray[0];

            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                int possibleSequenceNumber = inputArray[i];
                int comparator = inputArray[i + 1];

                if (possibleSequenceNumber != comparator)
                {
                    // Record the best sequence in terms of how many times the number
                    // has been seen
                    if (sequenceNumberTimesSeen > bestSequenceNumberTimesSeen)
                    {
                        bestSequenceNumber = sequenceNumber;
                        bestSequenceNumberTimesSeen = sequenceNumberTimesSeen;
                    }

                    // Record the first sequence ever seen
                    if (sequenceNumberTimesSeen > 1 && !isFirstSequence) 
                    {
                        firstSequenceNumber = sequenceNumber;
                        firstSequenceNumberTimesSeen = sequenceNumberTimesSeen;
                        isFirstSequence = true;
                    }

                    sequenceNumberTimesSeen = 1;
                    continue;
                }
                else if (possibleSequenceNumber == comparator)
                {
                    sequenceNumber = possibleSequenceNumber;
                    sequenceNumberTimesSeen++;
                }
            }

            // Case if the nubmers are the same
            if (sequenceNumberTimesSeen > bestSequenceNumberTimesSeen)
            {
                bestSequenceNumber = sequenceNumber;
                bestSequenceNumberTimesSeen = sequenceNumberTimesSeen;
            }

            // Case if no number repeats more than 1 time
            if (sequenceNumber == -1)
            {
                bestSequenceNumber = firstArrayNumber;
                bestSequenceNumberTimesSeen = 1;
            }

            // Case if all sequences are the same lenght
            if (firstSequenceNumberTimesSeen == bestSequenceNumberTimesSeen)
            {
                for (int i = 0; i < firstSequenceNumberTimesSeen; i++)
                {
                    Console.Write($"{firstSequenceNumber} ");
                }
            }
            // Normal case
            else
            {
                for (int i = 0; i < bestSequenceNumberTimesSeen; i++)
                {
                    Console.Write($"{bestSequenceNumber} ");
                }
            }
        }
    }
}
