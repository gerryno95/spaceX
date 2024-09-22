using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSpawnerController : MonoBehaviour
{
    [SerializeField] Transform[] spawnerPoints;
    [SerializeField] float waitTime = 1f;
    [SerializeField] GameObject prefab;

    [SerializeField] float minForce = 1f, maxForce = 2f;

    private void Start()
    {
        StartCoroutine(WaitAndSpawn());

    }

    IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            int number = (int)(Random.value * spawnerPoints.Length);
            GameObject newOb = Instantiate(prefab);
            newOb.SetActive(true);
            newOb.transform.position = spawnerPoints[number].position;
            newOb.transform.rotation = spawnerPoints[number].rotation;

            Rigidbody rb = newOb.GetComponent<Rigidbody>();
            rb.AddForce(newOb.transform.forward * Mathf.Lerp(minForce, maxForce, Random.value), ForceMode.Impulse);
        }
    }
}