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
        bestPos.text = ("ç≈çÇãLò^  " + ScoreManager.bestBallY.ToString());
        score.text = ("í«â¡ìæì_Å@" + ScoreManager.extraScore.ToString());
    }
}
