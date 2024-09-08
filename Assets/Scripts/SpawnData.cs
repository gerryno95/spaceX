using System.Collections;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnData", order = 1)]
public class SpawnData : ScriptableObject
{

    [Serializable]
    public class SpawnObject
    {
        public GameObject prefab;
        public float minSize = 1f;
        public float maxSize = 1f;
        public float probabilityOfSpawn = 1f;
    }

    [SerializeField] SpawnObject[] objects;


    public SpawnObject[] GetSpawnObjects()
    {
        return this.objects;
    }
}
