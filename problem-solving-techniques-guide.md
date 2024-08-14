# Comprehensive Guide to Problem-Solving Techniques and Concepts

## Techniques and Validity Considerations

1. **Two Pointer Technique**
   - **When to use:** Problems involving searching, comparing elements, or processing arrays/strings.
   - **Validity check:** Valid when the problem involves linear data structures and can benefit from processing elements from both ends or maintaining a window.
   - **Reasoning:** Reduces time complexity by avoiding nested loops.
   - **Deduction:** If the problem mentions pairs, subarrays, or requires comparing elements, consider this technique.

2. **Sliding Window**
   - **When to use:** Finding subarrays or substrings that satisfy certain conditions.
   - **Validity check:** Applicable when dealing with contiguous sequences and when the problem can be solved by expanding or contracting a window.
   - **Reasoning:** Efficiently processes subarrays by reusing computation from previous steps.
   - **Deduction:** If the problem involves finding a contiguous subset with certain properties, this technique may apply.

3. **Dynamic Programming (DP)**
   - **When to use:** Problems exhibiting optimal substructure and overlapping subproblems.
   - **Validity check:** Valid when the problem can be broken down into simpler subproblems and their solutions can be combined to solve the original problem.
   - **Reasoning:** Avoids redundant calculations by storing solutions to subproblems.
   - **Deduction:** If you find yourself solving the same subproblems repeatedly in a recursive approach, DP might be applicable.

4. **Greedy Algorithms**
   - **When to use:** Problems where making locally optimal choices leads to a global optimum.
   - **Validity check:** Ensure that the local optimal choice doesn't prevent finding the global optimum.
   - **Reasoning:** Simplifies decision-making by focusing on the best immediate choice.
   - **Deduction:** If the problem allows for step-by-step decision making without the need for looking ahead, consider a greedy approach.

5. **Divide and Conquer**
   - **When to use:** Problems that can be broken down into smaller, similar subproblems.
   - **Validity check:** Ensure that the problem can be divided into independent subproblems and their solutions can be combined.
   - **Reasoning:** Simplifies complex problems by solving smaller instances and combining results.
   - **Deduction:** If the problem involves recursively breaking down a larger problem into smaller ones, this approach may be suitable.

6. **Binary Search**
   - **When to use:** Searching in sorted arrays or when the search space can be systematically reduced.
   - **Validity check:** Applicable when the search space is sorted or can be represented as a range that can be halved in each step.
   - **Reasoning:** Efficiently reduces the search space by half in each iteration.
   - **Deduction:** If the problem involves finding a specific value or a condition in a sorted or monotonic sequence, consider binary search.

7. **Depth-First Search (DFS)**
   - **When to use:** Exploring paths in graphs or trees, backtracking problems.
   - **Validity check:** Valid for problems involving graph traversal, path finding, or exhaustive search with backtracking.
   - **Reasoning:** Explores as far as possible along each branch before backtracking.
   - **Deduction:** If the problem involves exploring all possible paths or configurations, DFS might be appropriate.

8. **Breadth-First Search (BFS)**
   - **When to use:** Finding shortest paths in unweighted graphs, level-order traversals.
   - **Validity check:** Applicable when you need to explore nodes in order of their distance from a starting point.
   - **Reasoning:** Guarantees finding the shortest path in unweighted graphs.
   - **Deduction:** If the problem involves finding the shortest path or processing nodes level by level, consider BFS.

## Key Concepts

1. **Window's Start and End**
   - **Concept:** In sliding window problems, maintain two pointers that define the current window being considered.
   - **How to solve:** Increment the end pointer to expand the window, and increment the start pointer to contract it. Update the solution based on the current window's properties.

2. **Optimal Substructure**
   - **Concept:** A problem has optimal substructure if an optimal solution can be constructed from optimal solutions of its subproblems.
   - **How to solve:** Break the problem into smaller subproblems, solve them optimally, and combine these solutions to solve the original problem. Often used in dynamic programming.

3. **Backtracking**
   - **Concept:** A general algorithm for finding all (or some) solutions to problems that incrementally builds candidates to the solution and abandons a candidate as soon as it determines the candidate cannot lead to a valid solution.
   - **How to solve:** Implement a recursive function that explores all possible choices. When a choice leads to an invalid path, backtrack by undoing the choice and exploring other options.

4. **Local Optimal Choice**
   - **Concept:** In greedy algorithms, making the best possible decision at each step without regard for future consequences.
   - **How to solve:** At each step, choose the option that seems best at the moment. Ensure that this strategy leads to the global optimum for the problem at hand.

5. **Memoization**
   - **Concept:** An optimization technique used primarily in dynamic programming to store the results of expensive function calls and return the cached result when the same inputs occur again.
   - **How to solve:** Use a data structure (often a hash table) to store results of subproblems. Before computing a subproblem, check if its result is already cached.

6. **State Machine**
   - **Concept:** Represent the problem as a set of states and transitions between these states based on certain conditions or inputs.
   - **How to solve:** Define the possible states and the rules for transitioning between them. Implement the logic to move between states based on the input or conditions of the problem.

7. **Monotonic Stack/Queue**
   - **Concept:** A stack or queue that maintains elements in a strictly increasing or decreasing order.
   - **How to solve:** When adding an element, remove elements that violate the monotonic property. This structure can efficiently solve problems involving finding the next greater/smaller element or maintaining a window of elements with certain properties.

Remember, the key to effective problem-solving is recognizing patterns and applying the appropriate technique. Practice analyzing problems to identify which of these concepts and techniques are applicable, and build experience in implementing them efficiently.

