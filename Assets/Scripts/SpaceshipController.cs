using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        if (bullet)
        {
            playerStatus.AddEnergy(-bullet.GetDamage());
        }
        flashController.Flash();
    }

    public void OpenRewardPack(RewardPack rewardPack)
    {

        switch (rewardPack)
        {
            case AmmoRewardPack ammoRewardPack:
                selectedWeapon.AddAmmo(ammoRewardPack.GetAmmo());
                break;

            case EnergyRewardPack energyRewardPack:
                playerStatus.AddEnergy(energyRewardPack.GetEnergy());
                break;
            default: throw new NotImplementedException();
        }
    }
}
