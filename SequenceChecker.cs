using System;
using System.Collections.Generic;
using System.Linq;

namespace Hacker_Challenge_6_17_21 {
    class SequenceChecker {
        bool debug = false;

        int[] firstArray;
        int[] secondArray;

        bool result;

        // public methods -------------------------------------------------------------

        // initializes the first and second arrays
        public void Initialize(int[] first, int[] second, bool d = false) {
            firstArray = first;
            secondArray = second;
            debug = d;
        }

        // driver method to display relevant information, call the checker and display the result
        public void PerformCheck() {
            Console.WriteLine("First Array: " + string.Join(", ", firstArray));
            Console.WriteLine("Second Array: " + string.Join(", ", secondArray));

            result = IsSecondArrayASubsequenceOfFirstArray();
        }

        public bool GetResult() {
            return result;
        }

        // private methods -------------------------------------------------------------

        // checker method
        private bool IsSecondArrayASubsequenceOfFirstArray() {
            List<int> foundMatches = GetFoundMatches();

            if (debug) {
                Console.WriteLine("[DEBUG] Second Array: " + string.Join(", ", secondArray));
                Console.WriteLine("[DEBUG] Found Matches: " + string.Join(", ", foundMatches.ToArray()));
            }

            return Enumerable.SequenceEqual(foundMatches.ToArray(), secondArray);
        }

        // helper method to get found matches in order of discovery
        private List<int> GetFoundMatches() {
            List<int> foundMatches = new List<int>();

            int index = 0;
            for (int i = 0; i < firstArray.Length; i++) {

                if (debug) { Console.WriteLine("[DEBUG] Comparing " + firstArray[i] + " with " + secondArray[index]); }

                if (firstArray[i] == secondArray[index]) {
                    foundMatches.Add(firstArray[i]);
                    index++;
                }

                if (index == secondArray.Length) {
                    // we have already found the sequence, further checking would result in an exception
                    break;
                }
            }
            return foundMatches;
        }
    }

    class Driver {
        static void Main() {
            int[] firstArray = new int[] { 1, 2, 3, 4 };
            int[] secondArray = new int[] { 1, 3, 4 };

            bool result = IsSubsequence(firstArray, secondArray);

            Console.WriteLine("Is the second array a subsequence of the first array? " + result);
        }

        // Hacker Challenge Method
        static bool IsSubsequence(int[] first, int[] second) {
            SequenceChecker checker = new SequenceChecker();
            checker.Initialize(first, second);
            checker.PerformCheck();
            return checker.GetResult();
        }
    }
}