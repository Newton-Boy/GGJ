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
        if (path != null && index < path.Count)
        {
            Vector3 targetPos = path[index].worldPosition;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                index++; // Pasamos al siguiente nodo
            }
        }
    }
}
