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
    // Start is called before the first frame update
    void Start()
    {
        State = GameState.RUNNNING;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        State = GameState.GAME_OVER;

        if (onStateChange != null) {
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
