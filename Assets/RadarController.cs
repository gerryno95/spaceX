using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadarController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] RectTransform center;
    List<GameObject> targetDisplayed = new List<GameObject>();
    List<GameObject> enemies = new List<GameObject>();
    private void Start()
    {
        
    }
    private void Update()
    {
        enemies.Clear();
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] objects = scene.GetRootGameObjects();
        int targets = 0;
        for (int i = 0; i < objects.Length; i++) {
            if (objects[i].GetComponent<Enemy1Controller>()) {
                targets++;
                enemies.Add(objects[i]);
            }
        }

        for (int i = 0; i < targets; i++) {
            if (i>=targetDisplayed.Count) {
                GameObject newTarget =  Instantiate(target,transform);
                targetDisplayed.Add(newTarget);
            }
        }
        while (targets < targetDisplayed.Count) {
            GameObject toRemove = targetDisplayed[targetDisplayed.Count - 1];
            targetDisplayed.RemoveAt(targetDisplayed.Count - 1);
            Destroy(toRemove);
        }
    }
}
