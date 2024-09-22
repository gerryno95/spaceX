using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage = 0.2f; // ENCAPSULATION 

    public virtual float GetDamage()
    {
        return this.damage;
    }
}
