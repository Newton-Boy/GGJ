using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InputController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Vector2 movement;

    public Vector2 GetDirection() {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0) {
            movement.y = 0f;
        } else if (movement.y != 0) {
            movement.x = 0f;
        }

            return movement;
    }
}
