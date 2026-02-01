using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Patrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float detectionRange = 5f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float moveSpeed = 2f;

    public Vector2[] waypoints;
    public int actualWaypoint;
    public int expectedWaypoint;
    public GameObject Player;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Player.transform.position - transform.position;

        if (dir.magnitude <= detectionRange)
            return;

        Rotate(dir);

        Move(dir);
    }
    void Rotate(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
    void Move(Vector2 dir)
    {
        rb.linearVelocity = dir.normalized * moveSpeed;
    }

    void PatrolMovement()
    {
        if (waypoints.Length == 0) return;

        Vector2 target = waypoints[actualWaypoint];
        Vector2 dir = target - (Vector2)transform.position;

        Rotate(dir);
        Move(dir);

        if (dir.magnitude < 0.2f)
            RecalculateWaypoint();
    }

    void RecalculateWaypoint()
    {
        actualWaypoint = (actualWaypoint + 1) % waypoints.Length;
    }
}
