using UnityEngine;
using UnityEngine.Events;

public abstract class WeaponController : MonoBehaviour
{
    [SerializeField] int maxAmmo = 100;
    [SerializeField] int ammo = 100;
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