using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] SpaceshipMovement spaceship;
    [SerializeField] Vector3 spaceshipOffset;
    [SerializeField] Transform cameraAim;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = spaceship.transform.position + Quaternion.Euler(spaceship.GetCurretRotX(),spaceship.GetCurretRotY(),0f) * spaceshipOffset;
        transform.LookAt(cameraAim);

    }
}
