using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Player")]
public class Player : ScriptableObject
{
    public float maxVelocity;
    public float velocity;
    public Vector2 maxY;
    public Vector2 maxX;

    
}
