using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCodePractice
{
    public class Miscellaneous
    {
        // 1319. Number of Operations to Make Network Connected [MEDIUM] https://leetcode.com/problems/number-of-operations-to-make-network-connected/
        [Theory]
        [MemberData(nameof(GetNumberOfOperationsToMakeNetworkConnectedData))]
        public void NumberOfOperationsToMakeNetworkConnected(int n, int[][] connections, int expected)
        {
            int ans = 0;

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            for (int i = 0; i < connections.Length; i++)
            {
                if (dict.ContainsKey(connections[i][0]))
                {
                    dict[connections[i][0]].Add(connections[i][1]);
                }
                else
                {
                    dict[connections[i][0]] = new List<int> { connections[i][1] };
                }

                if (dict.ContainsKey(connections[i][1]))
                {
                    dict[connections[i][1]].Add(connections[i][0]);
                }
                else
                {
                    dict[connections[i][1]] = new List<int> { connections[i][0] };
                }
            }

            Assert.Equal(expected, ans);
        }

        public static IEnumerable<object[]> GetNumberOfOperationsToMakeNetworkConnectedData()
        {
            return new[]
            {
                new object[] { 4, new int[][]{ new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 2 } }, 1 },
                new object[] { 6, new int[][]{ new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 1, 2 }, new int[] { 1, 3 } }, 2 },
                new object[] { 6, new int[][]{ new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 1, 2 } }, -1 },
                new object[] { 5, new int[][]{ new int[] { 0, 1 }, new int[] { 3, 4 }, new int[] { 2, 3 } }, 0 },
            };
        }

        // 819. Most Common Word [Easy] https://leetcode.com/problems/most-common-word/
        // Given a paragraph and a list of banned words, return the most frequent word that is not in the list of banned words.  It is guaranteed there is at least one word that isn't banned, and that the answer is unique.
        // Words in the list of banned words are given in lowercase, and free of punctuation.  Words in the paragraph are not case sensitive.  The answer is in lowercase.
        /// <summary>
        /// 1 <= paragraph.length <= 1000.
        /// 0 <= banned.length <= 100.
        /// 1 <= banned[i].length <= 10.
        /// The answer is unique, and written in lowercase(even if its occurrences in paragraph may have uppercase symbols, and even if it is a proper noun.)
        /// paragraph only consists of letters, spaces, or the punctuation symbols !?',;.
        /// There are no hyphens or hyphenated words.
        /// Words only consist of letters, never apostrophes or other punctuation symbols.
        /// </summary>
        [Theory]
        [MemberData(nameof(GetMostCommonWordData))]
        public void MostCommonWord(string paragraph, string[] banned, string expected)
        {
            string ans = null;

            HashSet<string> banSet = new HashSet<string>();

            List<string> words = paragraph.ToLower().Split(new char[] { '\'', ' ', ',', '.', '?', '!', ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            words.RemoveAll(string.Empty.Equals);

            Dictionary<string, int> freq = new Dictionary<string, int>();

            foreach (string s in banned)
            {
                banSet.Add(s);
            }

            int count = 0;
            string commonWord = string.Empty;

            //Add words to dictionary
            foreach (string word in words)
            {
                if (!banSet.Contains(word))
                {
                    if (freq.ContainsKey(word))
                    {
                        freq[word]++;
                    }
                    else
                    {
                        freq[word] = 1;
                    }

                    if (freq[word] > count)
                    {
                        count = freq[word];
                        commonWord = word;
                    }
                }
            }

            ans = commonWord;


            Assert.Equal(expected, ans);
        }

        public static IEnumerable<object[]> GetMostCommonWordData()
        {
            return new[]
            {
                new object[] { "Bob hit a ball, the hit BALL flew far after it was hit.", new string[] { "hit" }, "ball" },
            };
        }


        // Day 2 of 30-Day LeetCoding Challenge https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/528/week-1/3284/
        // 202. Happy Number https://leetcode.com/problems/happy-number/
        // Write an algorithm to determine if a number is "happy".
        // A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits, 
        //and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.
        [Theory]
        [InlineData(19, true)]
        [InlineData(82, true)]
        [InlineData(16, false)]
        public void HappyNumber(int n, bool expected)
        {
            // 4/2/2020
            // Runtime: 44 ms (beats 58.59% of C# submissions)
            // Memory Usage: 16.7 MB
            bool ans = false;

            HashSet<int> seen = new HashSet<int>();

            int current = n;

            while (!seen.Contains(current) && current != 1)
            {
                seen.Add(current);

                int next = 0;
                int temp = current;
                while (temp != 0)
                {
                    int digit = temp % 10;
                    temp = temp / 10;
                    next += digit * digit; 
                }

                current = next;
            }

            ans = current == 1;

            Assert.Equal(expected, ans);
        }
    }
}
