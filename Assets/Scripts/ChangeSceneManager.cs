using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    private Scene currentScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "SampleScene")
        {
            SceneManager.LoadScene("Scene2");
        }

        if (currentScene.name == "Scene2")
        {
            SceneManager.LoadScene("Scene3");
        }

        if (currentScene.name == "Scene3")
        {
            SceneManager.LoadScene("PrincipalMenu");
        }
    }

}
