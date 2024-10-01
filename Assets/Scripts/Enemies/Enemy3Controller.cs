using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : MonoBehaviour
{
    [SerializeField] float forwardVel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * forwardVel);
    }

    public void OnCollision(CollisionData collisionData)
    {
        
    }
}
