using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] Vector3 center;
    [SerializeField] float gap = 400f;
    [SerializeField] float gapRandomOffset = 200f;
    [SerializeField] int size = 10;
    [SerializeField] SpawnData spawnData;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {

                    int len = spawnData.GetSpawnObjects().Length;
                    int number = (int)(Random.value * len);

                    if (Random.value > spawnData.GetSpawnObjects()[number].probabilityOfSpawn)
                        continue;

                    GameObject newObj = Instantiate<GameObject>(spawnData.GetSpawnObjects()[number].prefab);
                    newObj.transform.localScale = Vector3.one * Mathf.Lerp(spawnData.GetSpawnObjects()[number].minSize,
                        spawnData.GetSpawnObjects()[number].maxSize,
                        Random.value);
                    Vector3 position = Vector3.zero + center;

                    float gapOffset = Mathf.Lerp(-gapRandomOffset, gapRandomOffset, Random.value);

                    position.x += i * gap + gapOffset;

                    gapOffset = Mathf.Lerp(-gapRandomOffset, gapRandomOffset, Random.value);

                    position.y += j * gap + gapOffset;

                    gapOffset = Mathf.Lerp(-gapRandomOffset, gapRandomOffset, Random.value);

                    position.z += k * gap + gapOffset;

                    newObj.transform.position = position;
                    newObj.transform.rotation = Quaternion.Euler(Random.value * 360f, Random.value * 360f, Random.value * 360f);

                }
            }
        }

    }


}
