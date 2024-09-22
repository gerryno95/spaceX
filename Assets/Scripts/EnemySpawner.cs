using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] int numEnemies = 20;
    float minDistance = 750f;
    float maxDistance = 1700f;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < numEnemies; i++) {
            GameObject enemy = Instantiate<GameObject>(enemy1);
            float distance = Mathf.Lerp(minDistance, maxDistance, Random.value);
            float yAngle = Random.value * 360f;
            float xAngle = Mathf.Lerp(-30, 30f, Random.value);
            enemy.transform.position =  Quaternion.Euler(xAngle, yAngle, 0) * Vector3.forward * distance;
            enemy.SetActive(true);

        }

    }

}
