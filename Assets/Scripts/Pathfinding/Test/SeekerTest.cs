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
                index = 0;

                // opcional: snap al nodo inicial
                NodeTest startNode = pathfinding.FindPath(transform.position, transform.position)[0];
                transform.position = startNode.worldPosition;
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    void Update()
    {
        if (path == null || index >= path.Count) return;

        Vector2 targetPos = path[index].worldPosition;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) < 0.05f)
        {
            index++;
        }
    }
}
