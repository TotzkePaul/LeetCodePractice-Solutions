using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCodePractice
{
    // Biweekly Contest 22 https://leetcode.com/contest/biweekly-contest-22
    public class BiweeklyContest22
    {

        // 1387. Sort Integers by The Power Value https://leetcode.com/contest/biweekly-contest-22/problems/sort-integers-by-the-power-value/
        [Theory]
        [InlineData(12, 15, 2, 13)]
        [InlineData(1, 1, 1, 1)]
        [InlineData(7, 11, 4, 7)]
        [InlineData(10, 20, 5, 13)]
        [InlineData(1, 1000, 777, 570)]
        public void SortIntegersByThePowerValue(int lo, int hi, int k, int expected)
        {
            int ans = 0;
            int[] arr = new int[hi - lo + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = getpower(lo + i);
            }

            var list = arr.Select((x, index) => new { Power = x, X = index + lo }).ToList();

            ans = list.OrderBy(x => x.Power).ThenBy(x => x.X).Skip(k - 1).First().X;

            Assert.Equal(expected, ans);
        }

        public int getpower(int x)
        {
            if (x == 1)
            {
                return 0;
            }
            int y = (x % 2 == 0) ? x / 2 : 3 * x + 1;
            return 1 + getpower(y);
        }
    }
}
