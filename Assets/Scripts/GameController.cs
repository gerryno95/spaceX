using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IGA.UnityHelpers;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    public enum GameState
    {
        RUNNNING,
        GAME_OVER
    }
    public GameState State { get; private set; }

    [SerializeField] UnityEvent onStateChange;
    [SerializeField] UnityEvent onGameOver;

    public bool IsLevelCompleted { get; private set; }

    int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        State = GameState.RUNNNING;
        Enemy1Controller[] enemy1s = FindObjectsOfType<Enemy1Controller>();
        enemyCount = enemy1s.Length;
        for (int i = 0; i < enemy1s.Length; i++)
        {
            enemy1s[i].GetComponent<PlayerStatus>().GetOnDead().AddListener(() => EnemyDead());

        }
    }

    void EnemyDead()
    {
        enemyCount--;
        if (enemyCount == 0)
        {
            State = GameState.GAME_OVER;
            IsLevelCompleted = true;
            GameOver();
        }
    }

    public void GameOver()
    {
        State = GameState.GAME_OVER;

        if (onStateChange != null)
        {
            onStateChange.Invoke();
        }
        if (onGameOver != null)
        {
            onGameOver.Invoke();
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
