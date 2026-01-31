using UnityEngine;
using System.Collections.Generic;

public class GridTest : MonoBehaviour
{
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public NodeTest[,] grid;

    private float nodeDiameter;
    private int gridSizeX, gridSizeY;

    void Awake()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new NodeTest[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius)
                                                   + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));
                grid[x, y] = new NodeTest(walkable, worldPoint, x, y);
            }
        }
    }

    public List<NodeTest> GetNeighbours(NodeTest node)
    {
        List<NodeTest> neighbours = new List<NodeTest>();

        int x = node.gridX;
        int y = node.gridY;

        // Arriba
        if (y + 1 < gridSizeY) neighbours.Add(grid[x, y + 1]);
        // Abajo
        if (y - 1 >= 0) neighbours.Add(grid[x, y - 1]);
        // Izquierda
        if (x - 1 >= 0) neighbours.Add(grid[x - 1, y]);
        // Derecha
        if (x + 1 < gridSizeX) neighbours.Add(grid[x + 1, y]);

        return neighbours;
    }

    public NodeTest NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }
}
