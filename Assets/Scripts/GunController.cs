using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : WeaponController
{
    [SerializeField] ParticleSystem[] projectiles;
    [SerializeField] float fireRatio;
    [SerializeField] LayerMask aimLayerMask;
    [SerializeField] Transform leftGun, rightGun;

    bool canFire = true;

    Camera camera;

    protected override void Awake()
    {
        base.Awake();
        camera = Camera.main;
    }

    public override void Fire()
    {
        if (canFire && GetAmmo()>0)
        {
            Vector3 aimTarget = CalculateAimTarget();

            Quaternion aimRot = Quaternion.LookRotation(aimTarget - leftGun.position);
            leftGun.rotation = aimRot;

            aimRot = Quaternion.LookRotation(aimTarget - rightGun.position);
            rightGun.rotation = aimRot;

            foreach (ParticleSystem proj in projectiles)
            {
                proj.Play();
            }

            AddAmmo(-1);

            if (onFire != null) {
                onFire.Invoke(this);
            }
            canFire = false;
            StartCoroutine(WaitToFire());
        }
    }
    IEnumerator WaitToFire()
    {
        yield return new WaitForSeconds(fireRatio);
        canFire = true;
    }

    Vector3 CalculateAimTarget()
    {

        Vector3 lookAtPosition = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 200f)) - camera.transform.position;
        Ray ray = new Ray(camera.transform.position, lookAtPosition);

        RaycastHit hitData;
        Vector3 aimTarget = camera.transform.position + lookAtPosition.normalized * 2000f;
        if (Physics.Raycast(ray, out hitData, 2000f, aimLayerMask))
        {
            aimTarget = hitData.point;
        }
        return aimTarget;

    }
  
}
