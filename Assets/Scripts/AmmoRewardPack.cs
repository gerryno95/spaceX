using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRewardPack : RewardPack
{
    [SerializeField] int ammo;

    public override void OnBulletCollision(CollisionData collisionData)
    {
        if (isEnabled)
        {
            GameObject spaceship = collisionData.other.transform.root.gameObject;
            SpaceshipController controller = spaceship.GetComponent<SpaceshipController>();
            if (controller)
            {
                controller.OpenRewardPack(this);
            }
            isEnabled = false;
        }
    }

    public int GetAmmo()
    {
        return ammo;
    }
}
