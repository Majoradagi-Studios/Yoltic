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
        if (currentScene.name == "Escena1")
        {
            SceneManager.LoadScene("Escena2");
        }

        if (currentScene.name == "Escena2")
        {
            SceneManager.LoadScene("PrincipalMenu");
        }

        /*
        if (currentScene.name == "Escena3")
        {
            SceneManager.LoadScene("PrincipalMenu");
        }}
        */
    }

}
