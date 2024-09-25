using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMotor : MonoBehaviour
{
    [SerializeField] Vector3 rotationVel;
    [SerializeField] Vector3 translationVel;
    [SerializeField] Space space;

    private void Update()
    {
        transform.Rotate(rotationVel * Time.deltaTime,space);
        transform.Translate(translationVel * Time.deltaTime,space);
    }
}
