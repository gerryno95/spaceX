using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    [SerializeField] GameObject star;
    [SerializeField] int starNumber = 1000;
    [SerializeField] Transform spaceship;
    [SerializeField] Color color1;
    [SerializeField] Color color2;

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.Instance;

        star.SetActive(false);
        for (int i = 0; i < starNumber; i++)
        {
            GameObject newStar = Instantiate<GameObject>(star, transform);
            newStar.SetActive(true);
            float minDist = 1000f;
            float maxDist = 1200f;
            float yAngle = Random.value * 360f;
            float xAngle = Mathf.Lerp(-80, 80f, Random.value);
            float dist = Mathf.Lerp(minDist, maxDist, Random.value);
            newStar.transform.position = transform.position + Quaternion.Euler(xAngle, yAngle, 0) * Vector3.forward * dist;

            Material material = newStar.GetComponent<ParticleSystemRenderer>().material;
            material.SetFloat("_emissionFreq", Mathf.Lerp(0f, 5f, Random.value));
            if (Random.value < 0.5f)
            {
                material.SetFloat("_emissionFreq", 0f);
            }
            material.SetFloat("_emissionAmp", Mathf.Lerp(0.1f, 0.5f, Random.value));
            material.SetColor("_Color", Color.Lerp(color1, color2, Random.value) * 5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = spaceship.position;

    }
}
