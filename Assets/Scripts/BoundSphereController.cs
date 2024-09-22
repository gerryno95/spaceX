using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BoundSphereController : MonoBehaviour
{
    [SerializeField] Transform spaceship;
    [SerializeField] UnityEvent onActivate;
    [SerializeField] UnityEvent onDeactivate;
    [SerializeField] float energyDecrVel = 0.2f;

    PlayerStatus spaceshipPlayerStatus;
    Collider collider;
    GameController gameController;
    bool isInside;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        spaceshipPlayerStatus = spaceship.GetComponent<PlayerStatus>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.State == GameController.GameState.GAME_OVER)
        {
            return;
        }
        if (collider.ClosestPoint(spaceship.position) == spaceship.position)
        {
            if (!isInside)
            {
                isInside = true;
                Deactivate();
            }
        }
        else
        {
            if (isInside)
            {
                isInside = false;
                Activate();
            }

            spaceshipPlayerStatus.AddEnergy(-energyDecrVel * Time.deltaTime);

        }
    }

    void Deactivate()
    {
        if (onDeactivate != null)
        {
            onDeactivate.Invoke();
        }
    }

    void Activate()
    {
        if (onActivate != null)
        {
            onActivate.Invoke();
        }
    }
}
