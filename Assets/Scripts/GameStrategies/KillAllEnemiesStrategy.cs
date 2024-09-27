using System.Collections;
using UnityEngine;


public class KillAllEnemiesStrategy : MonoBehaviour
{
    int enemyCount;
    EventCollector eventCollector;
    GameController gameController;
    // Use this for initialization
    void Start()
    {
        GameObject[] enemy1s = GameObject.FindGameObjectsWithTag("enemy");
        enemyCount = enemy1s.Length;
        eventCollector = EventCollector.Instance;
        eventCollector.onGeneralEvent.AddListener(OnGeneralEvent);

        gameController = GameController.Instance;
    }
    public void OnGeneralEvent(EventData eventData)
    {
        if (eventData.eventType == EventData.EventType.ENEMY_DEAD)
        {
            enemyCount--;
            if (enemyCount == 0)
            {
                gameController.IsLevelCompleted = true;
                gameController.GameOver();
            }
        }
    }

}
