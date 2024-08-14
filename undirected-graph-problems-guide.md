# Comprehensive Guide for Undirected Graph Problems

## Common Problem Types

1. Graph Traversal
2. Connectivity and Components
3. Cycle Detection
4. Shortest Path
5. Minimum Spanning Tree
6. Graph Coloring
7. Bipartite Graph Check

## Strategies and Techniques

### 1. Graph Traversal

#### Depth-First Search (DFS)
**When to use:** When you need to explore all paths in the graph or when the problem involves backtracking.

**Example Problem:** DFS traversal of a graph

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
    1: [0, 2],
    2: [0, 1, 3],
    3: [2]
}
dfs(graph, 0)
```

**Why it works:** DFS explores each branch to its full depth before backtracking, which is ideal for problems requiring complete path exploration.

#### Breadth-First Search (BFS)
**When to use:** When you need to find the shortest path in an unweighted graph or explore nodes level by level.

**Example Problem:** BFS traversal of a graph

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

**Why it works:** BFS explores nodes in order of their distance from the start node, making it ideal for shortest path problems in unweighted graphs.

### 2. Connectivity and Components

#### Union-Find (Disjoint Set)
**When to use:** When dealing with connected components, especially in dynamic graphs where edges are being added.

**Example Problem:** Number of Connected Components

```python
class UnionFind:
    def __init__(self, n):
        self.parent = list(range(n))
        self.rank = [0] * n
        self.count = n
    
    def find(self, x):
        if self.parent[x] != x:
            self.parent[x] = self.find(self.parent[x])
        return self.parent[x]
    
    def union(self, x, y):
        px, py = self.find(x), self.find(y)
        if px == py:
            return False
        if self.rank[px] < self.rank[py]:
            self.parent[px] = py
        elif self.rank[px] > self.rank[py]:
            self.parent[py] = px
        else:
            self.parent[py] = px
            self.rank[px] += 1
        self.count -= 1
        return True

def countComponents(n, edges):
    uf = UnionFind(n)
    for x, y in edges:
        uf.union(x, y)
    return uf.count

# Usage
n = 5
edges = [[0,1], [1,2], [3,4]]
print(countComponents(n, edges))  # Output: 2
```

**Why it works:** Union-Find efficiently maintains and merges connected components as edges are added, with near-constant time operations.

### 3. Cycle Detection

#### DFS Cycle Detection
**When to use:** When you need to determine if an undirected graph contains a cycle.

**Example Problem:** Detect Cycle in an Undirected Graph

```python
def hasCycle(graph):
    def dfs(node, parent):
        visited.add(node)
        for neighbor in graph[node]:
            if neighbor not in visited:
                if dfs(neighbor, node):
                    return True
            elif neighbor != parent:
                return True
        return False
    
    visited = set()
    for node in graph:
        if node not in visited:
            if dfs(node, -1):
                return True
    return False

# Usage
graph = {
    0: [1, 2],
    1: [0, 2],
    2: [0, 1, 3],
    3: [2]
}
print(hasCycle(graph))  # Output: True
```

**Why it works:** By keeping track of the parent node, we can distinguish between a back edge (indicating a cycle) and the edge we just came from.

### 4. Shortest Path

#### Breadth-First Search (for unweighted graphs)
**When to use:** When finding the shortest path in an unweighted graph.

**Example Problem:** Shortest Path between Two Nodes

```python
from collections import deque

def shortestPath(graph, start, end):
    queue = deque([(start, [start])])
    visited = set([start])
    
    while queue:
        (node, path) = queue.popleft()
        if node == end:
            return path
        
        for neighbor in graph[node]:
            if neighbor not in visited:
                visited.add(neighbor)
                queue.append((neighbor, path + [neighbor]))
    
    return None

# Usage
graph = {
    0: [1, 2],
    1: [0, 2, 3],
    2: [0, 1, 4],
    3: [1, 4],
    4: [2, 3]
}
print(shortestPath(graph, 0, 4))  # Output: [0, 2, 4]
```

**Why it works:** BFS guarantees that the first time we reach the end node, we've found the shortest path in an unweighted graph.

### 5. Minimum Spanning Tree

#### Kruskal's Algorithm
**When to use:** When finding the minimum spanning tree of a weighted undirected graph.

**Example Problem:** Minimum Spanning Tree

```python
def kruskalMST(n, edges):
    def find(x):
        if parent[x] != x:
            parent[x] = find(parent[x])
        return parent[x]
    
    def union(x, y):
        px, py = find(x), find(y)
        if px != py:
            if rank[px] < rank[py]:
                parent[px] = py
            elif rank[px] > rank[py]:
                parent[py] = px
            else:
                parent[py] = px
                rank[px] += 1
    
    parent = list(range(n))
    rank = [0] * n
    edges.sort(key=lambda x: x[2])  # Sort edges by weight
    mst = []
    
    for u, v, weight in edges:
        if find(u) != find(v):
            union(u, v)
            mst.append((u, v, weight))
    
    return mst

# Usage
n = 4
edges = [(0,1,10), (0,2,6), (0,3,5), (1,3,15), (2,3,4)]
print(kruskalMST(n, edges))
```

**Why it works:** Kruskal's algorithm greedily selects the lowest weight edges that don't create a cycle, efficiently building the minimum spanning tree.

### 6. Graph Coloring

#### Greedy Coloring
**When to use:** When assigning colors to vertices such that no two adjacent vertices have the same color.

**Example Problem:** Graph Coloring

```python
def greedyColoring(graph):
    result = {}
    for node in graph:
        used_colors = set(result.get(neighbor) for neighbor in graph[node] if neighbor in result)
        result[node] = next(color for color in range(len(graph)) if color not in used_colors)
    return result

# Usage
graph = {
    0: [1, 2],
    1: [0, 2, 3],
    2: [0, 1, 3],
    3: [1, 2]
}
print(greedyColoring(graph))
```

**Why it works:** The greedy approach assigns the lowest available color to each node, ensuring that adjacent nodes have different colors.

### 7. Bipartite Graph Check

#### Two-Coloring
**When to use:** When checking if a graph can be divided into two sets of nodes such that all edges connect nodes from different sets.

**Example Problem:** Is Graph Bipartite?

```python
def isBipartite(graph):
    color = {}
    
    def dfs(node):
        for neighbor in graph[node]:
            if neighbor in color:
                if color[neighbor] == color[node]:
                    return False
            else:
                color[neighbor] = 1 - color[node]
                if not dfs(neighbor):
                    return False
        return True
    
    for node in graph:
        if node not in color:
            color[node] = 0
            if not dfs(node):
                return False
    return True

# Usage
graph = {
    0: [1, 3],
    1: [0, 2],
    2: [1, 3],
    3: [0, 2]
}
print(isBipartite(graph))  # Output: True
```

**Why it works:** By attempting to color the graph with two colors, we can determine if it's bipartite. If at any point we can't assign a different color to an adjacent node, the graph is not bipartite.

## General Tips for Undirected Graph Problems

1. **Choose the right representation:** Decide between adjacency list and adjacency matrix based on the graph's density and the operations you need to perform.

2. **Consider space complexity:** For large graphs, be mindful of the space required for your chosen representation and algorithm.

3. **Optimize for specific graph types:** Some algorithms can be optimized for specific types of graphs (e.g., planar graphs, sparse graphs).

4. **Use appropriate data structures:** Utilize queues for BFS, stacks for DFS, and priority queues for algorithms like Dijkstra's.

5. **Handle disconnected graphs:** Remember to handle cases where the graph might not be fully connected.

6. **Preprocess when beneficial:** Sometimes, preprocessing the graph (e.g., computing a transitive closure) can simplify subsequent operations.

7. **Consider edge cases:** Always consider edge cases such as empty graphs, graphs with a single node, and fully connected graphs.

Remember, many graph problems have multiple valid approaches. The choice between DFS, BFS, or more specialized algorithms often depends on the specific requirements of the problem and the nature of the graph itself.

