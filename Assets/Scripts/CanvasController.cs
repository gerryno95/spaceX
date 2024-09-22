using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject gameOverWindow;
    [SerializeField] GameObject gameOverWindowLevCompleted;

    GameController gameController;
    private void Start()
    {
        gameController = GameController.Instance;

    }

    public void GameOver()
    {
        if (gameController.IsLevelCompleted)
        {
            gameOverWindowLevCompleted.SetActive(true);
        }
        else
        {
            gameOverWindow.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
