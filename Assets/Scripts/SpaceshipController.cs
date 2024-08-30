using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] GunController gunController;
    WeaponController selectedWeapon;
    void Start()
    {
        selectedWeapon = gunController;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            selectedWeapon.Fire();
        }
    }
}
