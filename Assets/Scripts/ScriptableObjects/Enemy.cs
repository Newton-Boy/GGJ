using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Enemy")]
public class Enemy : ScriptableObject
{

    public enum Type { 
        SCREAMER = 1,
        FLASH = 2
    }

    public int maxhealth;
    public bool isDead;
    public float maxSpeed;
    public int damage;


}
