using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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
        Vector2 worldBottomLeft = (Vector2)transform.position - new Vector2(gridWorldSize.x / 2, gridWorldSize.y / 2);

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector2 worldPoint = worldBottomLeft + new Vector2(x * nodeDiameter + nodeRadius, y * nodeDiameter + nodeRadius);
                bool walkable = Physics2D.OverlapCircle(worldPoint, nodeRadius, unwalkableMask) == null;
                Debug.Log(walkable);
                grid[x, y] = new NodeTest(walkable, worldPoint, x, y);
            }
        }
    }

    public List<NodeTest> GetNeighbours(NodeTest node)
    {
        List<NodeTest> neighbours = new List<NodeTest>();
        int x = node.gridX;
        int y = node.gridY;

        if (y + 1 < gridSizeY) neighbours.Add(grid[x, y + 1]); // arriba
        if (y - 1 >= 0) neighbours.Add(grid[x, y - 1]);       // abajo
        if (x - 1 >= 0) neighbours.Add(grid[x - 1, y]);       // izquierda
        if (x + 1 < gridSizeX) neighbours.Add(grid[x + 1, y]); // derecha

        return neighbours;
    }

    public NodeTest NodeFromWorldPoint(Vector2 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.Clamp(Mathf.FloorToInt(percentX * gridSizeX), 0, gridSizeX - 1);
        int y = Mathf.Clamp(Mathf.FloorToInt(percentY * gridSizeY), 0, gridSizeY - 1);

        // Alternativa más precisa en los bordes:
        // int x = Mathf.Clamp(Mathf.RoundToInt((gridSizeX - 1) * percentX), 0, gridSizeX - 1);
        // int y = Mathf.Clamp(Mathf.RoundToInt((gridSizeY - 1) * percentY), 0, gridSizeY - 1);

        return grid[x, y];
    }
}
