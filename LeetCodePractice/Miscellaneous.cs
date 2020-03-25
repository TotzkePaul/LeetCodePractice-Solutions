using System;
using System.Collections.Generic;
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
    }
}
