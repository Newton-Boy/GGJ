using UnityEngine;

public class NodeTest
{
    public bool walkable;
    public Vector2 worldPosition;
    public int gridX, gridY;

    public int gCost = int.MaxValue;
    public int hCost;
    public NodeTest parent;

    public NodeTest(bool walkable, Vector2 worldPos, int x, int y)
    {
        this.walkable = walkable;
        this.worldPosition = worldPos;
        this.gridX = x;
        this.gridY = y;
    }

    public int fCost => gCost + hCost;
}