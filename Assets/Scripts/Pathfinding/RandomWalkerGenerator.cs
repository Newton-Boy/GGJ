using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkerGenerator : MonoBehaviour
{
//    public enum Grid
//    {
//        Floor,
//        Wall,
//        Empty
//    }

//    public Grid[,] grid;

//    public List<Walker> walkers;

//    [Header("Prefabs")]
//    public GameObject floorPrefab;
//    public GameObject wallPrefab;

//    [Header("Mapa")]
//    public int mapWidth = 20;
//    public int mapHeight = 15;
//    public float fillPercent = 0.5f;

//    [Header("Walkers")]
//    public int maxWalkers = 10;
//    public float walkerChangeChance = 0.5f;

//    [Header("Zonas prohibidas")]
//    public List<Vector2Int> forbiddenPositions;

//    [Header("Nodos y NPC")]
//    public Node nodePrefab;
//    public List<Node> nodeList;
//    public EnemyAI npc;

//    private int tileCount = 0;
//    private bool canDrawGizmos = false;

//    private void Awake()
//    {
//        InitializeGrid();
//    }

//    private void InitializeGrid()
//    {
//        // Inicializar grid vacío
//        grid = new Grid[mapWidth, mapHeight];
//        for (int x = 0; x < mapWidth; x++)
//        {
//            for (int y = 0; y < mapHeight; y++)
//            {
//                grid[x, y] = Grid.Empty;
//            }
//        }

//        walkers = new List<Walker>();

//        // Comenzar en el centro
//        Vector2 centerPos = new Vector2(mapWidth / 2, mapHeight / 2);

//        // Crear primer walker
//        Walker newWalker = new Walker(centerPos, GetDirection(), walkerChangeChance);
//        walkers.Add(newWalker);

//        // Pintar piso inicial
//        PaintFloor((int)centerPos.x, (int)centerPos.y);

//        // Generar resto del mapa
//        CreateFloors();

//        // Generar muros alrededor
//        CreateWalls();

//        // Crear nodos y conexiones
//        CreateNodes();
//    }

//    private Vector2 GetDirection()
//    {
//        int choice = Mathf.FloorToInt(Random.value * 4f);
//        switch (choice)
//        {
//            case 0: return Vector2.down;
//            case 1: return Vector2.up;
//            case 2: return Vector2.left;
//            case 3: return Vector2.right;
//            default: return Vector2.zero;
//        }
//    }

//    private void CreateFloors()
//    {
//        while ((float)tileCount / (mapWidth * mapHeight) < fillPercent)
//        {
//            for (int i = 0; i < walkers.Count; i++)
//            {
//                Walker curWalker = walkers[i];
//                Vector2Int pos = new Vector2Int((int)curWalker.pos.x, (int)curWalker.pos.y);

//                // Pintar solo si no está prohibido
//                if (!forbiddenPositions.Contains(pos))
//                {
//                    PaintFloor(pos.x, pos.y);
//                }
//            }

//            // Actualizar walkers
//            ChanceToRemove();
//            ChanceToRedirect();
//            ChanceToCreate();
//            UpdatePosition();
//        }
//    }

//    private void PaintFloor(int x, int y)
//    {
//        if (grid[x, y] == Grid.Empty)
//        {
//            grid[x, y] = Grid.Floor;
//            tileCount++;
//            Instantiate(floorPrefab, new Vector3(x + 0.5f, y + 0.5f, 0), Quaternion.identity, transform);
//        }
//    }

//    private void ChanceToRemove()
//    {
//        for (int i = walkers.Count - 1; i >= 0; i--)
//        {
//            if (Random.value < walkers[i].chanceToChange && walkers.Count > 1)
//                walkers.RemoveAt(i);
//        }
//    }

//    private void ChanceToRedirect()
//    {
//        for (int i = 0; i < walkers.Count; i++)
//        {
//            if (Random.value < walkers[i].chanceToChange)
//            {
//                Walker curWalker = walkers[i];
//                curWalker.dir = GetDirection();
//                walkers[i] = curWalker;
//            }
//        }
//    }

//    private void ChanceToCreate()
//    {
//        for (int i = 0; i < walkers.Count; i++)
//        {
//            if (Random.value < walkers[i].chanceToChange && walkers.Count < maxWalkers)
//            {
//                Walker newWalker = new Walker(walkers[i].pos, GetDirection(), walkerChangeChance);
//                walkers.Add(newWalker);
//            }
//        }
//    }

//    private void UpdatePosition()
//    {
//        for (int i = 0; i < walkers.Count; i++)
//        {
//            Walker w = walkers[i];
//            Vector2 nextPos = w.pos + w.dir;
//            Vector2Int nextIntPos = new Vector2Int((int)nextPos.x, (int)nextPos.y);

//            // Mantener dentro del grid y no pasar por zonas prohibidas
//            if (nextIntPos.x >= 1 && nextIntPos.x < mapWidth - 1 &&
//                nextIntPos.y >= 1 && nextIntPos.y < mapHeight - 1 &&
//                !forbiddenPositions.Contains(nextIntPos))
//            {
//                w.pos = nextPos;
//            }

//            walkers[i] = w;
//        }
//    }

//    private void CreateWalls()
//    {
//        for (int x = 0; x < mapWidth; x++)
//        {
//            for (int y = 0; y < mapHeight; y++)
//            {
//                if (grid[x, y] == Grid.Floor)
//                {
//                    TryPlaceWall(x + 1, y);
//                    TryPlaceWall(x - 1, y);
//                    TryPlaceWall(x, y + 1);
//                    TryPlaceWall(x, y - 1);
//                }
//            }
//        }
//    }

//    private void TryPlaceWall(int x, int y)
//    {
//        if (x < 0 || x >= mapWidth || y < 0 || y >= mapHeight) return;

//        Vector2Int pos = new Vector2Int(x, y);
//        if (grid[x, y] == Grid.Empty && !forbiddenPositions.Contains(pos))
//        {
//            grid[x, y] = Grid.Wall;
//            Instantiate(wallPrefab, new Vector3(x + 0.5f, y + 0.5f, 0), Quaternion.identity, transform);
//        }
//    }

//    private void CreateNodes()
//    {
//        nodeList = new List<Node>();

//        for (int x = 0; x < mapWidth; x++)
//        {
//            for (int y = 0; y < mapHeight; y++)
//            {
//                if (grid[x, y] == Grid.Floor)
//                {
//                    Node node = Instantiate(nodePrefab, new Vector2(x + 0.5f, y + 0.5f), Quaternion.identity);
//                    nodeList.Add(node);
//                }
//            }
//        }

//        CreateConnections();
//    }

//    private void CreateConnections()
//    {
//        for (int i = 0; i < nodeList.Count; i++)
//        {
//            for (int j = i + 1; j < nodeList.Count; j++)
//            {
//                if (Vector2.Distance(nodeList[i].transform.position, nodeList[j].transform.position) <= 1f)
//                {
//                    ConnectNodes(nodeList[i], nodeList[j]);
//                    ConnectNodes(nodeList[j], nodeList[i]);
//                }
//            }
//        }

//        canDrawGizmos = true;
//        SpawnAI();
//    }

//    private void ConnectNodes(Node from, Node to)
//    {
//        if (from == to) return;
//        from.connections.Add(to);
//    }

//    private void SpawnAI()
//    {
//        if (nodeList.Count == 0) return;

//        Node randNode = nodeList[Random.Range(0, nodeList.Count)];
//        EnemyAI newNPC = Instantiate(npc, randNode.transform.position, Quaternion.identity);
//        newNPC.currentNode = randNode;
//    }

//    private void OnDrawGizmos()
//    {
//        if (grid == null) return;

//        // Tamaño del escenario: dibujar cada celda
//        for (int x = 0; x < mapWidth; x++)
//        {
//            for (int y = 0; y < mapHeight; y++)
//            {
//                Vector3 pos = new Vector3(x + 0.5f, y + 0.5f, 0);

//                // Color según tipo de celda
//                if (grid[x, y] == Grid.Floor)
//                    Gizmos.color = Color.green;   // pisos
//                else if (grid[x, y] == Grid.Wall)
//                    Gizmos.color = Color.red;     // muros
//                else
//                    Gizmos.color = new Color(1f, 1f, 1f, 0.1f); // vacío, casi transparente

//                // Dibujar un cubo del tamaño de la celda
//                Gizmos.DrawCube(pos, Vector3.one * 0.9f);
//            }
//        }

//        // Dibujar zonas prohibidas
//        if (forbiddenPositions != null)
//        {
//            Gizmos.color = Color.blue;
//            foreach (Vector2Int fPos in forbiddenPositions)
//            {
//                Vector3 pos = new Vector3(fPos.x + 0.5f, fPos.y + 0.5f, 0);
//                Gizmos.DrawCube(pos, Vector3.one * 0.9f);
//            }
//        }
//    }
//}

//public class Walker
//{
//    public Vector2 pos;
//    public Vector2 dir;
//    public float chanceToChange;

//    public Walker(Vector2 p, Vector2 d, float c)
//    {
//        pos = p;
//        dir = d;
//        chanceToChange = c;
//    }
}
