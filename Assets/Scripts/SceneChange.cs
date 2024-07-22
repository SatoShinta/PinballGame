using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] ScoreManager scoreManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void Update()
    {
       if(gameManager != null && gameManager.gameOver == true)
        {
            ChangeSceneResult();
        }
    }


    public void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ChangeSceneResult()
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void ChangeSceneTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
