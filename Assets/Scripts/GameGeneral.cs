using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IGA.UnityHelpers;
using UnityEngine.SceneManagement;


public class GameGeneral : CrossSceneSingleton<GameGeneral>
{
    [SerializeField] GameProperties gameProperties;

    public void PlayLevel(int levelNumber) {
        SceneManager.LoadScene(1);
        
    }
}
