using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Seeker : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    PathfindingTest pathfinding;
    List<NodeTest> path;
    int index = 0;

    void Start()
    {
        pathfinding = FindFirstObjectByType<PathfindingTest>();
        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        while (true)
        {
            if (target != null)
            {
                path = pathfinding.FindPath(transform.position, target.position);
                index = 0; // Comenzamos desde el primer nodo del path
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    void FixedUpdate()
    {
        if (path == null || index >= path.Count)
        {
            return;  // No path o llegado
        }

        Vector2 targetPos = path[index].worldPosition;
        float dist = Vector2.Distance(transform.position, targetPos);

        if (dist < 0.15f)  // Tolerancia para saltar nodo
        {
            index++;
            if (index >= path.Count)
            {
                Debug.Log("<color=lime>¡LLEGADO AL TARGET!</color>");
                path = null;  // Reinicia
                return;
            }
            targetPos = path[index].worldPosition;  // Siguiente
        }

        // Movimiento suave
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
    }
}
