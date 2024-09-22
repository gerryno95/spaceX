using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField] UnityEvent<CollisionData> onParticleCollision;
    [SerializeField] UnityEvent<CollisionData> onCollisionEnter;
    private void OnParticleCollision(GameObject other)
    {
        CollisionData cd = new CollisionData();
        cd.other = other;
        onParticleCollision.Invoke(cd);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (onCollisionEnter != null) {
            CollisionData data = new CollisionData();
            data.other = collision.gameObject;
            data.collision = collision;
            onCollisionEnter.Invoke(data);

        }
    }
    public UnityEvent<CollisionData> GetOnParticleCollision() {
        return this.onParticleCollision;
    }
    
}
