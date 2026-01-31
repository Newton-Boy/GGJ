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
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    void Update()
    {
        if (path == null || index >= path.Count)
            return;

        Vector3 targetPos = path[index].worldPosition;
        targetPos.y = transform.position.y;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            index++;
        }
    }
}
