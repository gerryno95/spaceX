using UnityEngine;
using UnityEngine.Events;
// INHERITANCE This is the abstract Weapon class which is implemented by GunController
// and other weapons. It is used in SpaceshipController to decouple spaceship and weapons.
public abstract class WeaponController : MonoBehaviour
{
    [SerializeField] int maxAmmo = 100;
    [SerializeField] int ammo = 100; // ENCAPSULATION this parameter has one setter (AddAmmo) and one getter (GetAmmo) to control the ammo of the weapon 
    [SerializeField] protected UnityEvent<WeaponController> onFire;
    protected virtual void Awake()
    {
        if (ammo > maxAmmo)
            ammo = maxAmmo;
    }
    public abstract void Fire();
    public void AddAmmo(int incr)
    {
        ammo += incr;
        if (ammo < 0)
            ammo = 0;
        if (ammo > maxAmmo)
            ammo = maxAmmo;
    }
    public int GetAmmo()
    {
        return ammo;
    }
}