using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

        // reset
        foreach (NodeTest n in grid.grid)
        {
            n.gCost = int.MaxValue;
            n.hCost = 0;
            n.parent = null;
        }

        startNode.gCost = 0;

        List<NodeTest> openSet = new List<NodeTest> { startNode };
        HashSet<NodeTest> closedSet = new HashSet<NodeTest>();

        while (openSet.Count > 0)
        {
            NodeTest currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost ||
                    openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                return RetracePath(startNode, targetNode);
            }

            foreach (NodeTest neighbour in grid.GetNeighbours(currentNode))
            {
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                    continue;

                int newCost = currentNode.gCost + 1;
                if (newCost < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newCost;
                    neighbour.hCost = Mathf.Abs(neighbour.gridX - targetNode.gridX) + Mathf.Abs(neighbour.gridY - targetNode.gridY);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour)) openSet.Add(neighbour);
                }
            }
        }

        return null;
    }

    List<NodeTest> RetracePath(NodeTest startNode, NodeTest endNode)
    {
        List<NodeTest> path = new List<NodeTest>();
        NodeTest currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        return path;
    }
}
