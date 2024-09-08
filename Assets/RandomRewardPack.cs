using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomRewardPack : RewardPack
{
    [SerializeField] CollisionEvent collisionEventController;
    RewardPack[] controllers;
    RewardPack choosenReward; 
    private void Awake()
    {
        CalculateControllers();

        int num = (int)(Random.value * controllers.Length);
        choosenReward = controllers[num];
        for(int i = 0; i < controllers.Length; i++)
        {
            if (i != num)
            {
                Destroy(controllers[i]);
            }
        }
    }
    public override void OnBulletCollision(CollisionData collisionData)
    {
        choosenReward.OnBulletCollision(collisionData);
    }
    void CalculateControllers() {
        RewardPack[] packs = GetComponents<RewardPack>();
        RewardPack[] newPacks = (new List<RewardPack>(packs)).Where(item => !(item is RandomRewardPack)).ToArray();
        controllers = newPacks;
    }
}
