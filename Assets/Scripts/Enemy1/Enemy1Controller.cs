using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    [SerializeField] WeaponController gun;
    [SerializeField] Transform[] shipBasePieces;
    [SerializeField] float baseRotationVel = 1f;
    // Start is called before the first frame update
    [SerializeField] float maxVel = 10f;
    [SerializeField] float velDistanceMultiplier = 1f;
    [SerializeField] float maxFireDistance = 400f;
    [SerializeField] Transform targetPoint;
    [SerializeField] WeaponController weapon;

    FlashMeshRendererController flashController;
    PlayerStatus playerStatus;
    float sqrMaxFireDistance;
    float vel;
    GameController gameController;
    private void Awake()
    {
        sqrMaxFireDistance = maxFireDistance * maxFireDistance;
        flashController = GetComponent<FlashMeshRendererController>();
        playerStatus = GetComponent<PlayerStatus>();

        if (!targetPoint)
        {
            targetPoint = FindObjectOfType<SpaceshipController>().transform;
        }
    }

    void Start()
    {
        gameController = GameController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.State == GameController.GameState.GAME_OVER)
            return;

        foreach (Transform tr in shipBasePieces)
        {
            tr.Rotate(Vector3.up * baseRotationVel * Time.deltaTime);
        }

        //goto targetPoint
        Vector3 toTarget = targetPoint.position - transform.position;
        float sqrDis = toTarget.sqrMagnitude;
        vel = velDistanceMultiplier * sqrDis;
        vel = Mathf.Clamp(vel, 0, maxVel);
        transform.Translate(toTarget.normalized * Time.deltaTime * vel);

        //orient gun transform to aim the spaceship
        toTarget = targetPoint.position - gun.transform.position;
        Vector3 toTargetHor = new Vector3(toTarget.x, 0f, toTarget.z);
        float xAngle = -Mathf.Atan2(toTarget.y, toTargetHor.magnitude) * 180f / Mathf.PI;

        gun.transform.rotation = Quaternion.LookRotation(toTargetHor) * Quaternion.Euler(xAngle, 0, 0);

        if (toTarget.sqrMagnitude < sqrMaxFireDistance)
        {
            weapon.Fire();
        }
    }

    public void OnCollision(CollisionData data)
    {
        Hitted(data);
    }
    void Hitted(CollisionData data)
    {
        flashController.Flash();
        Bullet bullet = data.other.GetComponent<Bullet>();
        if (bullet)
        {
            playerStatus.AddEnergy(-bullet.GetDamage());
        }
        else
        {
            playerStatus.AddEnergy(float.MinValue);
        }
    }
    public void OnDead()
    {
        Destroy(gameObject, 4f);
    }
}
