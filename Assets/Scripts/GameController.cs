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

    public bool IsLevelCompleted { get;  set; }


    // Start is called before the first frame update
    void Start()
    {
        State = GameState.RUNNNING;
      
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
