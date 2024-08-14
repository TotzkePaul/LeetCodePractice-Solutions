# Top 8 Archetypes for 1D Array or String Problems

## 1. Two Pointer Technique

**When to use:** If you notice the problem involves searching for pairs, subarrays, or requires comparing elements from both ends of the array.

**Reasoning:** Two pointers allow you to process the array in a single pass, often reducing time complexity from O(n²) to O(n).

**Example problems:**
- Two Sum (sorted array)
- Container With Most Water
- Trapping Rain Water

**Deduction:** If the problem mentions "pair of elements" or "subarray with certain properties" and the array is sorted or order doesn't matter, consider using two pointers.

## 2. Sliding Window

**When to use:** If you notice the problem involves finding a contiguous subarray or substring that satisfies certain conditions.

**Reasoning:** Sliding window allows you to efficiently process subarrays or substrings by maintaining a window that expands or contracts based on certain conditions, often resulting in O(n) time complexity.

**Example problems:**
- Longest Substring Without Repeating Characters
- Minimum Size Subarray Sum
- Find All Anagrams in a String

**Deduction:** If the problem asks for the "longest," "shortest," or "optimal" subarray/substring that satisfies certain conditions, consider using a sliding window.

## 3. Prefix Sum

**When to use:** If you notice the problem involves calculating sums of subarrays or requires frequent range sum queries.

**Reasoning:** Prefix sum allows you to precompute cumulative sums, enabling O(1) time complexity for subsequent range sum queries.

**Example problems:**
- Range Sum Query - Immutable
- Contiguous Array
- Subarray Sum Equals K

**Deduction:** If the problem involves multiple queries about subarray sums or cumulative properties, consider using prefix sum.

## 4. Hash Table for Lookup

**When to use:** If you notice the problem requires frequent lookups, counting occurrences, or finding complements.

**Reasoning:** Hash tables provide O(1) average time complexity for insertions and lookups, making them ideal for problems that require quick access to element information.

**Example problems:**
- Two Sum (unsorted array)
- Contains Duplicate
- First Unique Character in a String

**Deduction:** If the problem involves finding elements that satisfy certain conditions or counting occurrences, consider using a hash table.

## 5. Stack for Parsing

**When to use:** If you notice the problem involves parsing expressions, matching parentheses, or maintaining a history of elements.

**Reasoning:** Stacks allow you to keep track of the most recent elements or operations, making them suitable for problems that require backtracking or maintaining order.

**Example problems:**
- Valid Parentheses
- Evaluate Reverse Polish Notation
- Daily Temperatures

**Deduction:** If the problem involves parsing nested structures, matching opening/closing elements, or keeping track of the most recent state, consider using a stack.

## 6. Monotonic Stack/Queue

**When to use:** If you notice the problem involves finding the next greater/smaller element or maintaining a sorted subset of elements.

**Reasoning:** Monotonic stacks/queues allow you to efficiently maintain a sorted order of elements, often reducing time complexity from O(n²) to O(n).

**Example problems:**
- Next Greater Element I
- Largest Rectangle in Histogram
- Sliding Window Maximum

**Deduction:** If the problem asks for the "next greater/smaller element" or requires maintaining a sorted subset of elements in a specific order, consider using a monotonic stack/queue.

## 7. Dynamic Programming

**When to use:** If you notice the problem exhibits optimal substructure and overlapping subproblems.

**Reasoning:** Dynamic programming allows you to solve complex problems by breaking them down into simpler subproblems and storing the results for reuse, often improving time complexity from exponential to polynomial.

**Example problems:**
- Longest Increasing Subsequence
- Maximum Subarray
- Coin Change

**Deduction:** If the problem asks for an optimal solution (maximum/minimum) and can be broken down into smaller, overlapping subproblems, consider using dynamic programming.

## 8. Bit Manipulation

**When to use:** If you notice the problem involves working with binary representations, flags, or sets.

**Reasoning:** Bit manipulation allows you to perform operations on individual bits, often resulting in more efficient solutions in terms of both time and space complexity.

**Example problems:**
- Single Number
- Counting Bits
- Subsets

**Deduction:** If the problem involves working with binary numbers, flags, or set operations, or if you need to optimize space usage for integer operations, consider using bit manipulation techniques.

## General Advice for Technique Selection

1. **Analyze the problem statement:** Look for keywords that hint at specific techniques (e.g., "subarray," "next greater," "optimal").

2. **Consider the constraints:** The size of the input and time/space complexity requirements can guide you towards appropriate techniques.

3. **Identify patterns:** Look for patterns in the example inputs/outputs that might suggest a particular approach.

4. **Start simple:** Begin with a brute-force approach to understand the problem better, then look for optimization opportunities.

5. **Combine techniques:** Some problems may require a combination of techniques. Don't hesitate to use multiple approaches in your solution.

6. **Practice pattern recognition:** The more problems you solve, the better you'll become at recognizing which techniques are appropriate for different problem types.

Remember, these archetypes and techniques are guidelines, not strict rules. Always be open to creative solutions and combinations of techniques to solve complex problems efficiently.

