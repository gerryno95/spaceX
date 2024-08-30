using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteController : MonoBehaviour
{
    [SerializeField] float cabinRotVel = 1f;
    [SerializeField] float rotRadius = 200f;
    [SerializeField] float angularVelocity = 1f;
    [SerializeField] Transform[] cabin;

    float angle = 0f;
    Vector3 center;
    Vector3 radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = transform.right * rotRadius;
        center = transform.position + radius;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform cab in cabin)
        {
            cab.Rotate(Vector3.forward * cabinRotVel * Time.deltaTime);
        }
        angle += angularVelocity * Time.deltaTime;
        if (angle > 360f) {
            angle -= 360f;
        }
        Vector3 newPos = center - Quaternion.Euler(0, angle, 0) * radius;
        transform.position = newPos;
        transform.rotation = Quaternion.Euler(0, angle , 0);
    }
}
