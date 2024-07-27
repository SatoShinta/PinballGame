using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    [SerializeField] Text bestPos;
    [SerializeField] Text score;

    public void Start()
    {
        Result();
    }


    public void Result()
    {
        bestPos.text = ("最高記録  " + ScoreManager.bestBallY.ToString());
        score.text = ("追加得点　" + ScoreManager.extraScore.ToString());
    }

    public void ScoreAdd()
    {
        ScoreManager.bestBallY +=ScoreManager.extraScore;
        bestPos.text = ("最終得点 " +ScoreManager.bestBallY.ToString());
    }
}
