using System.Collections.Generic;
using UnityEngine;

public class PathfindingTest : MonoBehaviour
{
    GridTest grid;

    void Awake()
    {
        grid = GetComponentInChildren<GridTest>();
    }

    public List<NodeTest> FindPath(Vector2 startPos, Vector2 targetPos)
    {
        NodeTest startNode = grid.NodeFromWorldPoint(startPos);
        NodeTest targetNode = grid.NodeFromWorldPoint(targetPos);

        Debug.Log($"<color=yellow>Start: {startNode.gridX},{startNode.gridY} walkable={startNode.walkable}</color>");
        Debug.Log($"<color=cyan>Target: {targetNode.gridX},{targetNode.gridY} walkable={targetNode.walkable}</color>");

        // ? Buscar nodo WALKABLE más cerca
        NodeTest actualStart = GetClosestWalkableNode(startNode, startPos);
        NodeTest actualTarget = GetClosestWalkableNode(targetNode, targetPos);

        if (actualStart == null)
        {
            Debug.LogError("¡No hay nodo walkable cerca del START!");
            return null;
        }
        if (actualTarget == null)
        {
            Debug.LogError("¡No hay nodo walkable cerca del TARGET!");
            return null;
        }

        Debug.Log($"<color=green>Actual Start: {actualStart.gridX},{actualStart.gridY}</color>");
        Debug.Log($"<color=magenta>Actual Target: {actualTarget.gridX},{actualTarget.gridY} (dist: {Vector2.Distance(actualTarget.worldPosition, targetPos):F1}u)</color>");

        // Reset nodos
        for (int x = 0; x < grid.gridSizeX; x++)
        {
            for (int y = 0; y < grid.gridSizeY; y++)
            {
                grid.grid[x, y].gCost = int.MaxValue;
                grid.grid[x, y].hCost = 0;
                grid.grid[x, y].parent = null;
            }
        }

        actualStart.gCost = 0;
        actualStart.hCost = Heuristic(actualStart, actualTarget);

        List<NodeTest> openSet = new List<NodeTest>() { actualStart };
        HashSet<NodeTest> closedSet = new HashSet<NodeTest>();

        while (openSet.Count > 0)
        {
            NodeTest currentNode = GetLowestFCostNode(openSet);  // Optimizado
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == actualTarget)
            {
                Debug.Log($"<color=lime>¡PATH ENCONTRADO! {RetracePath(actualStart, actualTarget).Count} nodos</color>");
                return RetracePath(actualStart, actualTarget);
            }

            foreach (NodeTest neighbour in grid.GetNeighbours(currentNode))  // ? Usa el de GridTest
            {
                if (!neighbour.walkable || closedSet.Contains(neighbour)) continue;

                int newGCost = currentNode.gCost + 10;  // Cost straight
                if (newGCost < neighbour.gCost)
                {
                    neighbour.gCost = newGCost;
                    neighbour.hCost = Heuristic(neighbour, actualTarget);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour)) openSet.Add(neighbour);
                }
            }
        }

        Debug.Log("<color=red>No hay camino al nodo más cercano</color>");
        return null;
    }

    // ? Helpers optimizados
    NodeTest GetLowestFCostNode(List<NodeTest> openSet)
    {
        NodeTest lowest = openSet[0];
        for (int i = 1; i < openSet.Count; i++)
        {
            if (openSet[i].fCost < lowest.fCost ||
                (openSet[i].fCost == lowest.fCost && openSet[i].hCost < lowest.hCost))
            {
                lowest = openSet[i];
            }
        }
        return lowest;
    }

    int Heuristic(NodeTest nodeA, NodeTest nodeB)
    {
        int dx = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dy = Mathf.Abs(nodeA.gridY - nodeB.gridY);
        return (dx + dy) * 10;  // Manhattan scaled
    }

    NodeTest GetClosestWalkableNode(NodeTest centerNode, Vector2 worldPos)
    {
        List<NodeTest> candidates = new List<NodeTest>();
        int x = centerNode.gridX;
        int y = centerNode.gridY;
        int sizeX = grid.gridSizeX;
        int sizeY = grid.gridSizeY;

        // 3x3 alrededor (9 nodos)
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                int nx = x + dx;
                int ny = y + dy;
                if (nx >= 0 && nx < sizeX && ny >= 0 && ny < sizeY)
                {
                    candidates.Add(grid.grid[nx, ny]);
                }
            }
        }

        NodeTest closest = null;
        float minDist = float.MaxValue;
        foreach (NodeTest cand in candidates)
        {
            if (cand.walkable)
            {
                float dist = Vector2.Distance(cand.worldPosition, worldPos);
                if (dist < minDist)
                {
                    minDist = dist;
                    closest = cand;
                }
            }
        }
        return closest ?? centerNode;  // Fallback si nada
    }

    List<NodeTest> RetracePath(NodeTest start, NodeTest end)
    {
        List<NodeTest> path = new List<NodeTest>();
        NodeTest current = end;
        while (current != start)
        {
            path.Add(current);
            current = current.parent;
        }
        path.Reverse();
        return path;
    }
}