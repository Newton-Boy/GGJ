using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    InputController input;
    Rigidbody2D rb;

    public float smooth = 0.5f;
    public float speed = 1;
    public float maxSpeed = 1;

    private void OnEnable()
    {
        ItemEvents.OnItemPick += AffectSpeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<InputController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        rb.linearVelocity = input.GetDirection() * speed;
    }

    void AffectSpeed (ItemEvents.ItemEventArgs itemEvent){
        if (itemEvent.action == "add")
        {
            speed = speed - itemEvent.item.weight;
        }
        else {
            speed = maxSpeed;
        }
    }

}
