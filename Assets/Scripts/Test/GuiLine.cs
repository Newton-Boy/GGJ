using System.Collections.Generic;
using UnityEngine;

public class GuiLine : MonoBehaviour
{
    LineRenderer lineRenderer;

    public float maxDistanceLine;
    public Vector3 startPos;
    public Vector3 endPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
    }

    void DrawLine(){

        startPos = transform.position;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 direction = mousePos - startPos;

        if (direction.magnitude > maxDistanceLine) {
            direction = direction.normalized * maxDistanceLine;
        }

        endPos = startPos + direction;

        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);

    }

    public Dictionary<string, Vector2> GetDirections() {

        Dictionary<string, Vector2> directions = new Dictionary<string, Vector2>();

        directions.Add("start", startPos);
        directions.Add("end", endPos);
        directions.Add("direction", (endPos - startPos).normalized);

        return directions;
    
    }
}
