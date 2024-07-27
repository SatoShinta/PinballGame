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
        bestPos.text = ("�ō��L�^  " + ScoreManager.bestBallY.ToString());
        score.text = ("�ǉ����_�@" + ScoreManager.extraScore.ToString());
    }

    public void ScoreAdd()
    {
        ScoreManager.bestBallY +=ScoreManager.extraScore;
        bestPos.text = ("�ŏI���_ " +ScoreManager.bestBallY.ToString());
    }
}
