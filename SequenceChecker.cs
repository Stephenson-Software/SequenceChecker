using System;
using System.Collections.Generic;
using System.Linq;

namespace Hacker_Challenge_6_17_21
{
    class SequenceChecker
    {
        bool debug = false;

        int[] firstArray;
        int[] secondArray;

        public void Initialize(int[] first, int[] second, bool d = false) {
            firstArray = first;
            secondArray = second;
            debug = d;
        }

        public void PerformCheck() {
            Console.WriteLine("First Array: " + string.Join(", ", firstArray));
            Console.WriteLine("Second Array: " + string.Join(", ", secondArray));

            bool result = IsSecondArrayASubsequenceOfFirstArray();

            Console.WriteLine("Is the second array a subsequence of the first array? " + result);
        }

        public bool IsSecondArrayASubsequenceOfFirstArray() {
            List<int> foundMatches = GetFoundMatches();

            if (debug) {
                Console.WriteLine("[DEBUG] Second Array: " + string.Join(", ", secondArray));
                Console.WriteLine("[DEBUG] Found Matches: " + string.Join(", ", foundMatches.ToArray()));
            }

            return Enumerable.SequenceEqual(foundMatches.ToArray(), secondArray);
        }

        public List<int> GetFoundMatches() {
            List<int> foundMatches = new List<int>();

            int index = 0;
            for (int i = 0; i < firstArray.Length; i++) {
                if (index == secondArray.Length) {
                    return null;
                }

                if (debug) { Console.WriteLine("[DEBUG] Comparing " + firstArray[i] + " with " + secondArray[index]); }

                if (firstArray[i] == secondArray[index]) {
                    foundMatches.Add(firstArray[i]);
                    index++;
                }
            }
            return foundMatches;
        }

        static void Main() {
            SequenceChecker checker = new SequenceChecker();

            int[] firstArray = new int[] { 1, 2, 3, 4 };
            int[] secondArray = new int[] { 1, 3, 4 };

            checker.Initialize(firstArray, secondArray);

            checker.PerformCheck();
        }
    }
}
