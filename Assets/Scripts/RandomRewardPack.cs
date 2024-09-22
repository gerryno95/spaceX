using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomRewardPack : RewardPack
{
    [SerializeField] CollisionEvent collisionEventController;
    [SerializeField] ParticleSystem explosion;
    RewardPack[] controllers;
    RewardPack choosenReward;

    private void Awake()
    {
        CalculateControllers();

        int num = (int)(Random.value * controllers.Length);
        choosenReward = controllers[num];
        for (int i = 0; i < controllers.Length; i++)
        {
            if (i != num)
            {
                Destroy(controllers[i]);
            }
        }
    }
    public override void OnBulletCollision(CollisionData collisionData)
    {
        if (isEnabled)
        {
            choosenReward.OnBulletCollision(collisionData);
            isEnabled = false;

            OnOpened();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        SpaceshipController spaceshipController = collision.transform.root.GetComponent<SpaceshipController>();
        
        if (spaceshipController && isEnabled)
        {
            isEnabled = false;
            spaceshipController.OpenRewardPack(choosenReward);

            OnOpened();
           
        }
    }
    private void OnOpened()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(GetComponent<Rigidbody>());
        explosion.Play();
        Destroy(gameObject, 1f);
    }
    void CalculateControllers()
    {
        RewardPack[] packs = GetComponents<RewardPack>();
        RewardPack[] newPacks = (new List<RewardPack>(packs)).Where(item => !(item is RandomRewardPack)).ToArray();
        controllers = newPacks;
    }

}
