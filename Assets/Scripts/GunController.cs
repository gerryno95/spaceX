using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : WeaponController
{
    [SerializeField] ParticleSystem[] projectiles;
    [SerializeField] float fireRatio;

    bool canFire = true;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Fire()
    {
        if (canFire)
        {
            foreach (ParticleSystem proj in projectiles)
            {
                proj.Play();
            }

            canFire = false;
            StartCoroutine(WaitToFire());
        }
    }
    IEnumerator WaitToFire() {
        yield return new WaitForSeconds(fireRatio);
        canFire = true;
    }
}
