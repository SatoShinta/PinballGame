using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    [SerializeField] Text bestPos;
    [SerializeField] Text score;

    public void Result()
    {
        bestPos.text = ("�ō��L�^  " + ScoreManager.bestBallY.ToString());
        score.text = ("�ǉ����_�@" + ScoreManager.extraScore.ToString());
    }
}
