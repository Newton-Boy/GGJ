using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node cameFrom;
    public List<Node> connections = new List<Node>();
    public bool walkable = true;

    public float gScore;
    public float hScore;

    public float FScore()
    {
        return gScore + hScore;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = walkable ? Color.green : Color.red;

        Gizmos.DrawSphere(transform.position, 0.1f);

        if (connections.Count > 0)
        {
            Gizmos.color = Color.blue;
            for (int i = 0; i < connections.Count; i++)
            {
                Gizmos.DrawLine(transform.position, connections[i].transform.position);
            }
        }
    }
}
