using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] float forwardVel = 10f;
    [SerializeField] float rotationYFactor =1f;
    [SerializeField] float curvationYFactor = 1f;
    [SerializeField] float rotationXFactor = 1f;


    float rotY = 0f;
    float rotX = 0f;

    float currentRotY;
    float currentRotX;


    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.State == GameController.GameState.GAME_OVER)
            return;

        float deltaHor = Input.GetAxis("Mouse X");
        float deltaVer = Input.GetAxis("Mouse Y");

        deltaHor = Mathf.Clamp(deltaHor, -3, 3);
        rotY = rotY + deltaHor;
        rotX = rotX + deltaVer;
        rotX = Mathf.Clamp(rotX, -40f, 40f);

        currentRotX = Mathf.Lerp(currentRotX, rotX, Time.deltaTime * rotationXFactor); 
        currentRotY = Mathf.Lerp(currentRotY, rotY, Time.deltaTime * rotationYFactor);

        float curvationY = -curvationYFactor * (rotY - currentRotY);
        curvationY = Mathf.Clamp(curvationY, -45f, 45f);
        transform.rotation = Quaternion.Euler(currentRotX, currentRotY, curvationY);


        transform.Translate(Vector3.forward * forwardVel * Time.deltaTime);
        
    }

    public float GetCurretRotY()
    {
        return currentRotY;
    }

    public float GetCurretRotX()
    {
        return currentRotX;
    }
}
