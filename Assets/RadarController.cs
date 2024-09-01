using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadarController : MonoBehaviour
{
    [SerializeField] float radius = 40f;
    [SerializeField] float scaleDistance = 1f;
    [SerializeField] float maxDistance = 600f;
    [SerializeField] GameObject target;
    [SerializeField] RectTransform center;

    List<GameObject> targetDisplayed = new List<GameObject>();
    List<GameObject> enemies = new List<GameObject>();
    Camera camera;
    float sqrMaxDistance;

    private void Awake()
    {
        camera = Camera.main;
    }
    private void Start()
    {
        sqrMaxDistance = maxDistance * maxDistance;

    }
    private void Update()
    {
        enemies.Clear();
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] objects = scene.GetRootGameObjects();
        int targets = 0;
        for (int i = 0; i < objects.Length; i++)
        {
            Enemy1Controller enemy = objects[i].GetComponent<Enemy1Controller>();
            if (enemy)
            {
                Vector3 toEnemy = (enemy.transform.position - camera.transform.position);

                if (Vector3.Dot(camera.transform.forward, toEnemy) > 0 && toEnemy.sqrMagnitude < sqrMaxDistance)
                {
                    targets++;
                    enemies.Add(objects[i]);
                }
            };
        }

        for (int i = 0; i < targets; i++)
        {
            GameObject newTarget;
            if (i >= targetDisplayed.Count)
            {
                newTarget = Instantiate(target, transform);
                targetDisplayed.Add(newTarget);
                newTarget.SetActive(true);

            }
            else
            {
                newTarget = targetDisplayed[i];
            }

            Vector3 distance = Quaternion.Inverse(camera.transform.rotation) * (enemies[i].transform.position - camera.transform.position);
            distance.y = 0;
            float dist = distance.magnitude;
            float value = dist * scaleDistance;
            value = Mathf.Clamp(value, 0f, 1f);

            Vector3 rotatedDistance = new Vector3(distance.x, distance.z, 0f);
            newTarget.GetComponent<RectTransform>().localPosition = center.localPosition + rotatedDistance.normalized * value * radius;

        }
        while (targets < targetDisplayed.Count)
        {
            GameObject toRemove = targetDisplayed[targetDisplayed.Count - 1];
            targetDisplayed.RemoveAt(targetDisplayed.Count - 1);
            Destroy(toRemove);
        }
       
    }
}
