using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIWeaponStatus : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] WeaponController weapon;
    private void Awake()
    {
        weapon = FindObjectOfType<GunController>();
    }
    private void Start()
    {
        textMesh.text = weapon.GetAmmo().ToString();
    }

    public void OnFire(WeaponController weaponController)
    {
        textMesh.text = weaponController.GetAmmo().ToString();
    }

}
