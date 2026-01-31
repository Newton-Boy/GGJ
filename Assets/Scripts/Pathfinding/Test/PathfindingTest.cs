using UnityEngine;
using System.Collections.Generic;

public class PathfindingTest : MonoBehaviour
{
    GridTest grid;

    void Awake()
    {
        grid = GetComponentInChildren<GridTest>();
    }

    public List<NodeTest> FindPath(Vector3 startPos, Vector3 targetPos)
    {
        NodeTest startNode = grid.NodeFromWorldPoint(startPos);
        NodeTest targetNode = grid.NodeFromWorldPoint(targetPos);

        List<NodeTest> openSet = new List<NodeTest>();
        HashSet<NodeTest> closedSet = new HashSet<NodeTest>();
        openSet.Add(startNode);

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

                int newCost = currentNode.gCost + 1; // 4 direcciones

                if (newCost < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newCost;
                    neighbour.hCost =
                        Mathf.Abs(neighbour.gridX - targetNode.gridX) +
                        Mathf.Abs(neighbour.gridY - targetNode.gridY); // Manhattan
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
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
