# Comprehensive Guide for Directed Graph Problems

## Common Problem Types

1. Graph Traversal
2. Topological Sorting
3. Strongly Connected Components
4. Cycle Detection
5. Shortest Path in Weighted Graphs
6. Transitive Closure
7. Minimum Spanning Arborescence

## Strategies and Techniques

### 1. Graph Traversal

#### Depth-First Search (DFS)
**When to use:** When you need to explore all paths in the graph or when the problem involves backtracking.

**Example Problem:** DFS traversal of a directed graph

```python
def dfs(graph, start, visited=None):
    if visited is None:
        visited = set()
    visited.add(start)
    print(start, end=' ')
    
    for neighbor in graph[start]:
        if neighbor not in visited:
            dfs(graph, neighbor, visited)

# Usage
graph = {
    0: [1, 2],
    1: [2],
    2: [0, 3],
    3: []
}
dfs(graph, 0)
```

**Why it works:** DFS explores each branch to its full depth before backtracking, which is ideal for problems requiring complete path exploration in directed graphs.

#### Breadth-First Search (BFS)
**When to use:** When you need to find the shortest path in an unweighted directed graph or explore nodes level by level.

**Example Problem:** BFS traversal of a directed graph

```python
from collections import deque

def bfs(graph, start):
    visited = set([start])
    queue = deque([start])
    
    while queue:
        vertex = queue.popleft()
        print(vertex, end=' ')
        
        for neighbor in graph[vertex]:
            if neighbor not in visited:
                visited.add(neighbor)
                queue.append(neighbor)

# Usage
bfs(graph, 0)
```

**Why it works:** BFS explores nodes in order of their distance from the start node, making it ideal for shortest path problems in unweighted directed graphs.

### 2. Topological Sorting

#### Kahn's Algorithm
**When to use:** When you need to find a linear ordering of vertices in a Directed Acyclic Graph (DAG) such that for every directed edge (u, v), vertex u comes before v in the ordering.

**Example Problem:** Course Schedule

```python
from collections import defaultdict, deque

def findOrder(numCourses, prerequisites):
    # Build the graph
    graph = defaultdict(list)
    in_degree = [0] * numCourses
    for course, prereq in prerequisites:
        graph[prereq].append(course)
        in_degree[course] += 1
    
    # Initialize queue with all courses having no prerequisites
    queue = deque([i for i in range(numCourses) if in_degree[i] == 0])
    order = []
    
    while queue:
        course = queue.popleft()
        order.append(course)
        for next_course in graph[course]:
            in_degree[next_course] -= 1
            if in_degree[next_course] == 0:
                queue.append(next_course)
    
    return order if len(order) == numCourses else []

# Usage
numCourses = 4
prerequisites = [[1,0],[2,0],[3,1],[3,2]]
print(findOrder(numCourses, prerequisites))
```

**Why it works:** Kahn's algorithm iteratively removes nodes with no incoming edges, ensuring that prerequisites are taken before dependent courses.

### 3. Strongly Connected Components

#### Kosaraju's Algorithm
**When to use:** When you need to find strongly connected components in a directed graph.

**Example Problem:** Find Strongly Connected Components

```python
from collections import defaultdict

def kosaraju(graph):
    def dfs(v, visited, stack):
        visited.add(v)
        for neighbor in graph[v]:
            if neighbor not in visited:
                dfs(neighbor, visited, stack)
        stack.append(v)
    
    def reverse_graph(graph):
        reversed_graph = defaultdict(list)
        for v in graph:
            for neighbor in graph[v]:
                reversed_graph[neighbor].append(v)
        return reversed_graph
    
    def dfs_scc(v, visited, component):
        visited.add(v)
        component.append(v)
        for neighbor in reversed_graph[v]:
            if neighbor not in visited:
                dfs_scc(neighbor, visited, component)
    
    visited = set()
    stack = []
    for v in graph:
        if v not in visited:
            dfs(v, visited, stack)
    
    reversed_graph = reverse_graph(graph)
    visited.clear()
    sccs = []
    
    while stack:
        v = stack.pop()
        if v not in visited:
            component = []
            dfs_scc(v, visited, component)
            sccs.append(component)
    
    return sccs

# Usage
graph = {
    0: [1, 3],
    1: [2],
    2: [0],
    3: [4],
    4: []
}
print(kosaraju(graph))
```

**Why it works:** Kosaraju's algorithm uses two DFS passes: one on the original graph to get finishing times, and another on the reversed graph to find SCCs.

### 4. Cycle Detection

#### DFS Cycle Detection
**When to use:** When you need to determine if a directed graph contains a cycle.

**Example Problem:** Detect Cycle in a Directed Graph

```python
def hasCycle(graph):
    def dfs(node):
        visited.add(node)
        rec_stack.add(node)
        
        for neighbor in graph[node]:
            if neighbor not in visited:
                if dfs(neighbor):
                    return True
            elif neighbor in rec_stack:
                return True
        
        rec_stack.remove(node)
        return False
    
    visited = set()
    rec_stack = set()
    
    for node in graph:
        if node not in visited:
            if dfs(node):
                return True
    return False

# Usage
graph = {
    0: [1, 2],
    1: [2],
    2: [0, 3],
    3: [3]
}
print(hasCycle(graph))  # Output: True
```

**Why it works:** By maintaining a recursion stack, we can detect back edges, which indicate cycles in a directed graph.

### 5. Shortest Path in Weighted Graphs

#### Dijkstra's Algorithm
**When to use:** When finding the shortest path in a weighted directed graph with non-negative edge weights.

**Example Problem:** Network Delay Time

```python
import heapq
from collections import defaultdict

def networkDelayTime(times, N, K):
    graph = defaultdict(list)
    for u, v, w in times:
        graph[u].append((v, w))
    
    pq = [(0, K)]
    dist = {}
    
    while pq:
        d, node = heapq.heappop(pq)
        if node in dist:
            continue
        dist[node] = d
        
        for neighbor, weight in graph[node]:
            if neighbor not in dist:
                heapq.heappush(pq, (d + weight, neighbor))
    
    return max(dist.values()) if len(dist) == N else -1

# Usage
times = [[2,1,1],[2,3,1],[3,4,1]]
N = 4
K = 2
print(networkDelayTime(times, N, K))
```

**Why it works:** Dijkstra's algorithm greedily selects the node with the smallest known distance and relaxes its outgoing edges, efficiently finding the shortest paths from a single source.

### 6. Transitive Closure

#### Floyd-Warshall Algorithm
**When to use:** When you need to find the shortest paths between all pairs of vertices in a weighted graph, including finding if there's a path between any two vertices.

**Example Problem:** Transitive Closure of a Graph

```python
def transitiveClosure(graph):
    n = len(graph)
    closure = [row[:] for row in graph]
    
    for k in range(n):
        for i in range(n):
            for j in range(n):
                closure[i][j] = closure[i][j] or (closure[i][k] and closure[k][j])
    
    return closure

# Usage
graph = [
    [1, 1, 0, 1],
    [0, 1, 1, 0],
    [0, 0, 1, 1],
    [0, 0, 0, 1]
]
print(transitiveClosure(graph))
```

**Why it works:** Floyd-Warshall considers all possible intermediate vertices to find paths between each pair of vertices, effectively computing the transitive closure.

### 7. Minimum Spanning Arborescence

#### Edmonds' Algorithm (Chu–Liu/Edmonds' algorithm)
**When to use:** When finding the minimum spanning tree of a directed graph (also known as minimum spanning arborescence or optimal branching).

**Example Problem:** Minimum Spanning Arborescence

```python
from collections import defaultdict

def find(parent, i):
    if parent[i] == i:
        return i
    return find(parent, parent[i])

def union(parent, rank, x, y):
    xroot = find(parent, x)
    yroot = find(parent, y)
    if rank[xroot] < rank[yroot]:
        parent[xroot] = yroot
    elif rank[xroot] > rank[yroot]:
        parent[yroot] = xroot
    else:
        parent[yroot] = xroot
        rank[xroot] += 1

def minimum_spanning_arborescence(n, edges, root):
    edges.sort(key=lambda x: x[2])  # Sort edges by weight
    parent = list(range(n))
    rank = [0] * n
    result = []
    
    for u, v, weight in edges:
        if find(parent, u) != find(parent, v):
            union(parent, rank, u, v)
            result.append((u, v, weight))
    
    # Check if the result forms a valid arborescence rooted at 'root'
    if len(result) != n - 1:
        return None
    
    # Verify that all nodes are reachable from the root
    graph = defaultdict(list)
    for u, v, _ in result:
        graph[u].append(v)
    
    visited = set()
    def dfs(node):
        visited.add(node)
        for neighbor in graph[node]:
            if neighbor not in visited:
                dfs(neighbor)
    
    dfs(root)
    if len(visited) != n:
        return None
    
    return result

# Usage
n = 4
edges = [(0, 1, 10), (0, 2, 5), (2, 1, 2), (2, 3, 1), (1, 3, 4)]
root = 0
print(minimum_spanning_arborescence(n, edges, root))
```

**Why it works:** This implementation uses a modified Kruskal's algorithm to find the minimum spanning tree, then verifies that it forms a valid arborescence rooted at the specified node.

## General Tips for Directed Graph Problems

1. **Consider edge direction:** Always be mindful of the direction of edges when traversing or analyzing the graph.

2. **Handle strongly connected components:** Many problems can be simplified by first decomposing the graph into its strongly connected components.

3. **Use topological sorting:** For problems involving dependencies or ordering, consider if topological sorting can be applied.

4. **Be aware of cycles:** Directed graphs can have cycles, which can complicate many algorithms. Always consider how to handle or detect cycles.

5. **Optimize for DAGs:** If the graph is known to be a Directed Acyclic Graph (DAG), many algorithms can be optimized or simplified.

6. **Consider reversing the graph:** Some problems become easier when you consider the reverse of the graph (all edge directions flipped).

7. **Use appropriate data structures:** Choose between adjacency lists, adjacency matrices, and edge lists based on the graph's density and the required operations.

Remember, directed graphs often require more careful handling of edge cases and cycle detection compared to undirected graphs. Always consider the implications of edge direction when adapting algorithms from undirected to directed graphs.

