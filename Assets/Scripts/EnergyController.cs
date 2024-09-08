using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{
    [SerializeField] PlayerStatus spaceshipStatus;
    [SerializeField] Image energyImage;

    Material energyMaterial;
    private void Awake()
    {
        energyMaterial = energyImage.material;
    }

    // Start is called before the first frame update
    void Start()
    {
        float value = spaceshipStatus.GetEnergy() * 28f;

        energyMaterial.SetFloat("_energy", Mathf.Clamp(value, 2f, 28f));
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EnergyChanged()
    {
        float value = spaceshipStatus.GetEnergy() * 28f;

        energyMaterial.SetFloat("_energy", Mathf.Clamp(value, 2f, 28f));
    }
}
