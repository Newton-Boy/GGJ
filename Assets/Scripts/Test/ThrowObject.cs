using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public Rigidbody2D throwableObj;
    public float throwForce;
    public float maxTrowForce;
    public float throwPower;

    public float currentThrowingTime;
    public float throwingTime;
    public float maxThrowingTime;
    public Vector2 direction;

    GuiLine guiLine;
    Vector2 initialDir;
    Vector2 finalDir;

    public bool powering;
    public bool poweringRelease;

    public bool isThrowing;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        guiLine = GetComponentInChildren<GuiLine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanThrow())
            return;

        if (Input.GetKeyDown(KeyCode.V) && !isThrowing) {
            powering = true;
            poweringRelease = false;
        }

        if (Input.GetKeyUp(KeyCode.V) && !isThrowing) {
            poweringRelease = true;
        }

        CalculatePower();

        if (isThrowing)
        {
            CalculateForce();
        }


    }

    void Throw() {
        if (isThrowing) {
            Dictionary<string, Vector2> directions = guiLine.GetDirections();
            initialDir = directions["start"];
            finalDir = directions["end"];
            direction = directions["direction"];
        } 
    }

    bool CanThrow()
    {
        return ItemManager.instance.HasThrowable() && !isThrowing;
    }

    void CalculateForce() {

        if (isThrowing) {
            Vector2 objPos = throwableObj.transform.position;
            float finalDirPowered = finalDir.magnitude * Mathf.Clamp(throwPower, 0.5f, 1.5f);

            throwableObj.linearVelocity = direction;


            if (objPos.magnitude >= finalDirPowered)
            {
                throwableObj.linearVelocity = Vector2.zero;
                isThrowing = false;
            }
        }
    }

    void CalculatePower() {

        if (powering)
        {
            currentThrowingTime += Time.deltaTime;
            if (currentThrowingTime >= maxThrowingTime || poweringRelease) {
                throwPower = Mathf.Floor(currentThrowingTime);
                currentThrowingTime = 0;
                isThrowing = true;
                powering = false;
                Throw();
            }

        }


    }
}
