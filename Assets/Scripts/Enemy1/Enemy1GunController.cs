using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1GunController : WeaponController
{
    [SerializeField] Enemy1BulletController bullet;

 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndFire());
    }
    IEnumerator WaitAndFire() {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);
            Fire();
        }
    }
    public override void Fire()
    {
        GameObject newB = Instantiate<GameObject>(bullet.gameObject);
        newB.transform.position = bullet.transform.position;
        newB.transform.rotation = bullet.transform.rotation;
        newB.SetActive(true);
    }

}
