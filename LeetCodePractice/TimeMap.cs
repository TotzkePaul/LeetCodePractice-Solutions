using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCodePractice
{
    // 146. LRU Cache https://leetcode.com/problems/lru-cache/
    /*
     * Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and put.
     * get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
     * put(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.
     * The cache is initialized with a positive capacity.
     */
    public class TimeMapUnitTests
    {

        [Fact]
        public void TimeMapExampleOne()
        {
            TimeMap timeMap = new TimeMap();
            timeMap.Set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
            var t0 = timeMap.Get("foo", 1);         // return "bar"
            var t1 = timeMap.Get("foo", 3);         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
            timeMap.Set("foo", "bar2", 4); // store the key "foo" and value "ba2r" along with timestamp = 4.
            var t2 = timeMap.Get("foo", 4);         // return "bar2"
            var t3 = timeMap.Get("foo", 5);         // return "bar2"

            Assert.Equal("bar", t0);
            Assert.Equal("bar", t1);
            Assert.Equal("bar2", t2);
            Assert.Equal("bar2", t3);
        }

        [Fact]
        public void TimeMapExampleFortySeven()
        {
            TimeMap timeMap = new TimeMap();
            timeMap.Set("love", "high", 10);
            timeMap.Set("love", "low", 20);

            var t0 = timeMap.Get("love", 5);         
            var t1 = timeMap.Get("love", 10);
            var t2 = timeMap.Get("love", 15);    
            var t3 = timeMap.Get("love", 20);
            var t4 = timeMap.Get("love", 25);

            Assert.Equal("", t0);
            Assert.Equal("high", t1);
            Assert.Equal("high", t2);
            Assert.Equal("low", t3);
            Assert.Equal("low", t4);
        }
    }
    // Runtime: 820 ms, faster than 87.67% of C# online submissions for Time Based Key-Value Store.
    // Memory Usage: 106.8 MB, less than 52.33% of C# online submissions for Time Based Key-Value Store.
    public class TimeMap
    {

        /** Initialize your data structure here. */
        Dictionary<string, List<(int Timestamp, string Result)>> store;
        public TimeMap()
        {
            store = new Dictionary<string, List<(int, string)>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (store.ContainsKey(key))
            {
                store[key].Add((timestamp, value));
            } else
            {
                store[key] = new List<(int, string)> { (timestamp, value) };
            }
            
        }

        public string Get(string key, int timestamp)
        {
            if (store.ContainsKey(key))
            {
                var arr = store[key];
                if (timestamp < arr[0].Timestamp)
                {
                    return string.Empty;
                }
                int idx = BinarySearch(arr, timestamp);
                return arr[idx].Result;
            }

            return string.Empty;
        }

        protected int BinarySearch(List<(int Timestamp, string Result)> arr, int target)
        {
            int min = 0;
            int max = arr.Count - 1;
            if (target >= arr[max].Timestamp)
            {
                return max;
            }

            while (min < max)
            {
                int mid = (max - min) / 2;
                if (arr[mid].Timestamp == target)
                {
                    return mid;
                }
                else if (target < arr[mid].Timestamp)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }

            return min;
        }
    }
}
