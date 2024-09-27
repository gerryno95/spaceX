using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1GunController : WeaponController
{
    [SerializeField] Enemy1BulletController bullet;
    [SerializeField] float fireTime = 0.5f;
    bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {

    }
    IEnumerator WaitAndFire()
    {
        yield return new WaitForSeconds(fireTime);
        canFire = true;
    }

    public override void Fire()
    {
        if (canFire)
        {
            GameObject newB = Instantiate<GameObject>(bullet.gameObject);
            newB.transform.position = bullet.transform.position;
            newB.transform.rotation = bullet.transform.rotation;
            newB.SetActive(true);
            canFire = false;
            StartCoroutine(WaitAndFire());
        }
    }

}
