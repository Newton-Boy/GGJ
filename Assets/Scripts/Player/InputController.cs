using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InputController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Vector2 movement;
    Rigidbody2D rb;

    public float smooth = 0.5f;
    public float speed = 1f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * speed;
        movement.y = Input.GetAxisRaw("Vertical") * speed;

        Movement();
    }

    void Movement() {
        rb.linearVelocity = movement;
    }
}
