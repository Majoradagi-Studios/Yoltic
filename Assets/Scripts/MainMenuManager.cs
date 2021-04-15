using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Starts the game
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionMenu()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit the game");
    }
}
