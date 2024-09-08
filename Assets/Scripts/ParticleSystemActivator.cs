using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemActivator : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particleSystems;


    public void Play()
    {
        for(int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].Play();
        }
    }
}
