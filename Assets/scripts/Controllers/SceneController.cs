using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities; 

public class SceneController : MonoBehaviour
{


    public void Start_Level()
    {
        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL);
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(SceneNames.MAIN_MENU);
    }
    public void EndGame()
    {
        SceneManager.LoadSceneAsync(SceneNames.End_Game);
    }
     public void Options()
    {
        SceneManager.LoadSceneAsync(SceneNames.Options);
    }
    public void Rules()
    {
        SceneManager.LoadSceneAsync(SceneNames.Rules);
    }

    public void ExitGame() {
     Application.Quit();
    }


    public static SceneController FindSceneController()
    {
        SceneController sc = FindObjectOfType<SceneController>();
        if(!sc)
        {
            Debug.LogWarning("Missing SceneController");
        }
        return sc;
    }
    
}
