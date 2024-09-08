using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RewardPack : MonoBehaviour
{
    protected bool isEnabled = true;
    public abstract void OnBulletCollision(CollisionData collisionData);

}
