using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRewardPack : RewardPack
{
    [SerializeField] float energy;

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

    public float GetEnergy()
    {
        return energy;
    }
}
