using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InputController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Vector2 movement;

    public Vector2 GetDirection() {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        return movement;
    }
}
