using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    InputController input;
    Rigidbody2D rb;
    Animator animator;
    AudioSource audioSource;
    public float smooth = 0.5f;
    public float speed = 1;
    public float maxSpeed = 1;
    public Vector2 lastDir;
    public bool wasMoving;

    private void Awake()
    {
        ActionEvent.onActionExecuted += Relocate;
    }
    private void OnEnable()
    {
        ItemEvents.OnItemPick += AffectSpeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<InputController>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 dir = input.GetDirection().normalized; // normalized for diagonal movement
        bool isMoving = dir != Vector2.zero;

        animator.SetBool("isMoving", isMoving);

        if (isMoving)
            lastDir = dir;

        if (isMoving && !wasMoving)
        {
            audioSource.Play();
        }
        else if (!isMoving && wasMoving)
        {
            audioSource.Stop();
        }

        wasMoving = isMoving;

        animator.SetFloat("movementX", lastDir.x);
        animator.SetFloat("movementY", lastDir.y);

        rb.linearVelocity = dir * speed;
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

    void Relocate(ActionEvent.ActionEventArgs actionEvent) { 
        transform.position = actionEvent.actionData.newLocation;
    }

}
