using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum Phase {
        IDLE = 1,
        PATROL = 2
    }

    public Phase EnemyPhase = Phase.IDLE;
    public Vector2 patrolX, patrolY;

    Rigidbody2D rb;
    bool isDead;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead) { 
            Patrol();
        }
    }

    void LookAt() { 
    
    }

    void Grab() { }

    void Attack() { }

    void Hurt() { }

    void Walk() { }

    void Patrol() {

        //Necesita patrullar un maximo de x y un maximo de y
        // No tiene que ser fluido el camino seguido pero a la vez debe ser random
        // que calculo puede alcanzar algo asi

    }


}
