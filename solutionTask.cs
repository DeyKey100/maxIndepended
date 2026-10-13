using System;
using System.Collections.Generic;
class Program
{
    static List<int> GetMaximumIndependentSet(int[,] graph)
    {
        int n = graph.GetLength(0);
        List<int> bestSet = new List<int>();
        Backtrack(0, n, graph, new List<int>(), bestSet);
        return bestSet;
    }
    static void Backtrack(int vertex, int n, int[,] graph, List<int> currentSet, List<int> bestSet)
    {
        if (vertex == n)
        {
            if (currentSet.Count > bestSet.Count)
            {
                bestSet.Clear();
                bestSet.AddRange(currentSet);
            }
            return;
        }
        if (currentSet.Count + (n - vertex) <= bestSet.Count) return;
        bool canInclude = true;
        foreach (int v in currentSet)
        {
            if (graph[vertex, v] == 1) { canInclude = false; break; }
        }
        if (canInclude)
        {
            currentSet.Add(vertex);
            Backtrack(vertex + 1, n, graph, currentSet, bestSet);
            currentSet.RemoveAt(currentSet.Count - 1);
        }
        Backtrack(vertex + 1, n, graph, currentSet, bestSet);
    }

    static void Main()
    {
        int[,] graph = new int[,] {
            { 0, 1, 1, 0, 0 },
            { 1, 0, 1, 1, 0 },
            { 1, 1, 0, 0, 0 },
            { 0, 1, 0, 0, 1 },
            { 0, 0, 0, 1, 0 }
        };
        List<int> result = GetMaximumIndependentSet(graph);
        Console.WriteLine(string.Join(", ", result));
    }
}
