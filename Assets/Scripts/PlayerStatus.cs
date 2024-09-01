using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] float maxEnergy = 1f;
    [SerializeField] float energy = 1f;

    [SerializeField] UnityEvent onDead;
    [SerializeField] UnityEvent onEnergyChanged;

    public void AddEnergy(float energy)
    {
        this.energy += energy;
        this.energy = Mathf.Clamp(this.energy, 0f, maxEnergy);
        if (this.energy <= 0f)
        {
            if (onDead != null)
            {
                onDead.Invoke();
            }
        }
        if (onEnergyChanged != null) {
            onEnergyChanged.Invoke();
        }
    }

    public float GetEnergy() {
        return energy;
    }
}
