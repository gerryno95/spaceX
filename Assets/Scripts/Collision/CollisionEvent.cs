using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField] UnityEvent<CollisionData> onParticleCollision;
    private void OnParticleCollision(GameObject other)
    {
        CollisionData cd = new CollisionData();
        cd.other = other;
        onParticleCollision.Invoke(cd);
    }
}
