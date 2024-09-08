using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RadarController : MonoBehaviour
{
    class RadarTarget
    {
        public GameObject gameObject;
        public Color color;
    }
    [SerializeField] Color rewardColor = new Color(29f / 255, 168f / 255, 0f, 233f / 255f);
    [SerializeField] Color enemyColor = new Color(183f / 255, 0f, 0f, 233f / 255f);

    [SerializeField] float radius = 40f;
    [SerializeField] float scaleDistance = 1f;
    [SerializeField] float maxDistance = 600f;
    [SerializeField] GameObject target;
    [SerializeField] RectTransform center;

    List<GameObject> targetDisplayed = new List<GameObject>();
    List<RadarTarget> targets = new List<RadarTarget>();
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
        targets.Clear();
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] objects = scene.GetRootGameObjects();
        int totTargets = 0;
        for (int i = 0; i < objects.Length; i++)
        {
            RadarTarget newTarget = null;

            Enemy1Controller enemy = objects[i].GetComponent<Enemy1Controller>();

            if (enemy)
            {
                newTarget = new RadarTarget();
                newTarget.gameObject = objects[i];
                newTarget.color = enemyColor;

            };
            RewardPack rewardPack = objects[i].GetComponent<RewardPack>();
            if (rewardPack)
            {
                newTarget = new RadarTarget();
                newTarget.gameObject = objects[i];
                newTarget.color = rewardColor;
            };

            if (newTarget != null)
            {

                Vector3 toTarget = (newTarget.gameObject.transform.position - camera.transform.position);

                if (Vector3.Dot(camera.transform.forward, toTarget) > 0 && toTarget.sqrMagnitude < sqrMaxDistance)
                {
                    totTargets++;

                    targets.Add(newTarget);
                }
            }

        }

        for (int i = 0; i < totTargets; i++)
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

            Vector3 distance = Quaternion.Inverse(camera.transform.rotation) * (targets[i].gameObject.transform.position - camera.transform.position);
            distance.y = 0;
            float dist = distance.magnitude;
            float value = dist * scaleDistance;
            value = Mathf.Clamp(value, 0f, 1f);

            Vector3 rotatedDistance = new Vector3(distance.x, distance.z, 0f);
            newTarget.GetComponent<RectTransform>().localPosition = center.localPosition + rotatedDistance.normalized * value * radius;

            newTarget.GetComponent<Image>().color = targets[i].color;

        }
        while (totTargets < targetDisplayed.Count)
        {
            GameObject toRemove = targetDisplayed[targetDisplayed.Count - 1];
            targetDisplayed.RemoveAt(targetDisplayed.Count - 1);
            Destroy(toRemove);
        }

    }
}
