using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCodePractice
{
    // 981. Time Based Key-Value Store https://leetcode.com/problems/time-based-key-value-store/
    /*
     * Design a time-based key-value data structure that can store multiple values for the same key at different time stamps and retrieve the key's value at a certain timestamp.
     * 
     * Implement the TimeMap class:
     * TimeMap() Initializes the object of the data structure.
     * void set(String key, String value, int timestamp) Stores the key key with the value value at the given time timestamp.
     * String get(String key, int timestamp) Returns a value such that set was called previously, with timestamp_prev <= timestamp. 
     * If there are multiple such values, it returns the value associated with the largest timestamp_prev. If there are no values, it returns "".
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
    // Runtime: 788 ms, faster than 99.00% of C# online submissions for Time Based Key-Value Store.
    // Memory Usage: 107.1 MB, less than 41.00% of C# online submissions for Time Based Key-Value Store.
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
            if (!store.ContainsKey(key))
            {
                store[key] = new List<(int, string)>();
            }
            store[key].Add((timestamp, value));
        }

        public string Get(string key, int timestamp)
        {
            if (store.ContainsKey(key))
            {
                if (timestamp < store[key][0].Timestamp)
                {
                    return string.Empty;
                }
                int idx = BinarySearch(store[key], timestamp);
                return store[key][idx].Result;
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
                } else if (target < arr[mid].Timestamp)
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
