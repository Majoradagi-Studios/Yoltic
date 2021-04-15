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
    int score = 0;
    private YolticMovement yolticHealth;
    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (scoreManage == null)
        {
            scoreManage = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);

        if (currentScene.name == "PrincipalMenu")
        {
            DestroyImmediate(gameObject);
        }

        if (yolticHealth.Health == 0)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("Text").GetComponent<Text>();
            scoreText.text = score.ToString();
        }
        
    }
    public void RaiseScore(int s)
    {
        score += s;
        scoreText.text = score.ToString();
    }
}
