# Summary Guide for Data Structures and Algorithms

## 1. Arrays and Strings

### Two Pointer Technique
**When to use:** For problems involving searching for pairs, subarrays, or comparing elements from both ends of the array.
**Reasoning:** Allows processing the array in a single pass, often reducing time complexity from O(n²) to O(n).

### Sliding Window
**When to use:** For finding a contiguous subarray or substring that satisfies certain conditions.
**Reasoning:** Efficiently processes subarrays or substrings by maintaining a window that expands or contracts, often resulting in O(n) time complexity.

### Hash Table for Lookup
**When to use:** For frequent lookups, counting occurrences, or finding complements.
**Reasoning:** Provides O(1) average time complexity for insertions and lookups, ideal for quick access to element information.

## 2. Linked Lists

### Two-Pointer Technique
**When to use:** For cycle detection, finding the middle of the list, or operations requiring multiple traversals.
**Reasoning:** Allows detection of cycles or finding specific elements without extra space.

### Dummy Node
**When to use:** When the head of the list might change or when handling edge cases uniformly.
**Reasoning:** Simplifies edge cases, especially when removing or modifying the head of the list.

## 3. Stacks

### Using Stack for Tracking
**When to use:** For keeping track of elements in a Last-In-First-Out (LIFO) order.
**Reasoning:** Efficiently manages elements where the most recently added item is the first to be removed or processed.

## 4. Queues

### Level Order Processing
**When to use:** For processing elements level by level, such as in tree level order traversal.
**Reasoning:** Maintains breadth-first order, allowing processing of nodes or elements in the order they are encountered.

## 5. Trees

### Depth-First Search (DFS)
**When to use:** For exploring all paths to leaf nodes or when the problem involves backtracking.
**Reasoning:** Efficiently explores each branch to its full depth before backtracking.

### Breadth-First Search (BFS)
**When to use:** For finding the shortest path in an unweighted tree or processing nodes level by level.
**Reasoning:** Explores nodes in order of their distance from the root, ideal for level-wise operations.

## 6. Graphs

### Depth-First Search (DFS)
**When to use:** For exploring all paths in the graph or when the problem involves backtracking.
**Reasoning:** Allows complete exploration of paths, useful for cycle detection and topological sorting.

### Breadth-First Search (BFS)
**When to use:** For finding the shortest path in an unweighted graph or exploring nodes level by level.
**Reasoning:** Guarantees the shortest path in unweighted graphs and is efficient for level-wise exploration.

### Topological Sorting
**When to use:** For finding a linear ordering of vertices in a Directed Acyclic Graph (DAG).
**Reasoning:** Useful for scheduling problems and dependency resolution.

### Dijkstra's Algorithm
**When to use:** For finding the shortest path in a weighted graph with non-negative edge weights.
**Reasoning:** Efficiently finds the shortest paths from a single source to all other vertices.

## 7. Dynamic Programming

**When to use:** For problems with optimal substructure and overlapping subproblems.
**Reasoning:** Solves complex problems by breaking them down into simpler subproblems and storing results for reuse, often improving time complexity from exponential to polynomial.

## 8. Greedy Algorithms

**When to use:** When making locally optimal choices leads to a global optimum.
**Reasoning:** Provides simple, efficient solutions to optimization problems where local optimality leads to global optimality.

## 9. Divide and Conquer

**When to use:** For breaking down complex problems into smaller, more manageable subproblems.
**Reasoning:** Simplifies problem-solving by dividing large problems into smaller ones that are easier to solve, often leading to efficient recursive solutions.

## 10. Binary Search

**When to use:** For searching in a sorted array or when the search space can be systematically reduced.
**Reasoning:** Reduces the search space by half in each step, resulting in O(log n) time complexity.

## 11. Heaps

**When to use:** For problems involving the K-th largest/smallest element or priority queue operations.
**Reasoning:** Efficiently maintains a set of the K largest or smallest elements, with insertion and deletion in O(log k) time.

## 12. Trie (Prefix Tree)

**When to use:** For problems involving a large set of strings with common prefixes.
**Reasoning:** Allows efficient prefix-based operations, useful for autocomplete systems and word search problems.

## 13. Union-Find (Disjoint Set)

**When to use:** For problems involving set operations, particularly in graphs for connected components or cycle detection.
**Reasoning:** Provides near-constant time operations for merging sets and checking connectivity when implemented with path compression and union by rank.

Remember, the key to effective problem-solving is recognizing which data structure or algorithm is most appropriate for the given problem. Consider the nature of the data, the operations you need to perform, and the time and space complexity requirements when choosing your approach.

