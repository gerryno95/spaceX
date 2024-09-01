using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] GunController gunController;
    WeaponController selectedWeapon;
    FlashMeshRendererController flashController;
    PlayerStatus playerStatus;
    private void Awake()
    {
        flashController = GetComponent<FlashMeshRendererController>();
        playerStatus = GetComponent<PlayerStatus>();
    }
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
    public void OnCollision(CollisionData data)
    {
        Bullet bullet = data.other.GetComponent<Bullet>();
        if (bullet) {
            playerStatus.AddEnergy(-bullet.GetDamage());
        }
        flashController.Flash();
    }
}
