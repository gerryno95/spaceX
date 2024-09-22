using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using IGA.UnityHelpers;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] GunController gunController;
    [SerializeField] ActionInvoker explosion;
    [SerializeField] float enemyCollisionDamage = 0.3f;

    WeaponController selectedWeapon;
    FlashMeshRendererController flashController;
    PlayerStatus playerStatus;
    GameController gameController;
    

    private void Awake()
    {
        flashController = GetComponent<FlashMeshRendererController>();
        playerStatus = GetComponent<PlayerStatus>();
    }
    void Start()
    {
        selectedWeapon = gunController;
        gameController = GameController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.State == GameController.GameState.GAME_OVER)
            return;
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
            flashController.Flash();
        }
        else if (data.collision != null && data.collision.transform.tag == "rock")
        {
            playerStatus.AddEnergy(float.MinValue);
            Explode();
        }
        else
        {
            Enemy1Controller enemy1 = data.other.transform.root.GetComponent<Enemy1Controller>();
            if (enemy1)
            {
                playerStatus.AddEnergy(-enemyCollisionDamage);
            }
        }


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

    private void Explode()
    {
        explosion.Invoke();
    }
}
