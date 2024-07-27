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
        bestPos.text = ("最高記録  " + ScoreManager.bestBallY.ToString());
        score.text = ("追加得点　" + ScoreManager.extraScore.ToString());
    }
}
