using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManage : MonoBehaviour
{
    public static ScoreManage scoreManage;

    private Scene currentScene;
    public Text scoreText;
    public int score = 0;
    int Health;
    
    void Start()
    {
        Health = GameObject.FindGameObjectWithTag("Player").GetComponent<YolticMovement>().Health;
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "PrincipalMenu" )
        {
            DestroyImmediate(this);
        }

        if (Health == 0)
        {
            score = 0;
        }

        if (scoreManage == null)
        {
            scoreManage = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);

        
    }


    void Update()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.FindGameObjectWithTag("Coins").GetComponent<Text>();
            scoreText.text = score.ToString();
        }
        
    }
    public void RaiseScore(int s)
    {
        score += s;
        scoreText.text = score.ToString();
    }
}
