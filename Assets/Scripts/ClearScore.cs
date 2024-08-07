using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScore : MonoBehaviour
{
    [SerializeField,Header("最終得点")] Text saisyutokuten;
    [SerializeField, Header("追加得点")] Text tuikatokuten;
    [SerializeField, Header("クリアタイム得点")] Text kuriataimutokuten;
    [SerializeField, Header("敵撃破得点")] Text tekigekihatokuten;
    [SerializeField, Header("クリアしてくれてありがとうテキスト")] Text arigatoutokuten;
    [SerializeField, Header("クリアしてくれてありがとう得点")] Text arigatousukoa;

    public int bonasuscore;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameOverTimer *= 10f;
        bonasuscore = 1000000;
        CleaScore1();
    }

   
    public void CleaScore1()
    {
        saisyutokuten.text = ("最終得点 : " + ScoreManager.bestBallY.ToString());
        tuikatokuten.text = ("追加得点 : " + ScoreManager.extraScore.ToString());
        kuriataimutokuten.text = ("クリアタイムボーナス : " + Mathf.CeilToInt(GameManager.gameOverTimer).ToString());
        tekigekihatokuten.text = ("敵撃破ボーナス : " + BallCtr.destroyCounter2.ToString());
        arigatoutokuten.text = ("最後まで遊んでくれてありがとう！");
        arigatousukoa.text = (bonasuscore.ToString());
    }

    public void ClearScoreAdd1()
    {
        ScoreManager.bestBallY += ScoreManager.extraScore;
        saisyutokuten.text = ("最終得点 :" + ScoreManager.bestBallY.ToString());

    }

    public void ClearScoreAdd2()
    {
        ScoreManager.bestBallY += (int)GameManager.gameOverTimer;
        saisyutokuten.text = ("最終得点 :" + ScoreManager.bestBallY.ToString());

    }

    public void ClearScoreAdd3()
    {
        ScoreManager.bestBallY += BallCtr.destroyCounter2;
        saisyutokuten.text = ("最終得点 :" + ScoreManager.bestBallY.ToString());

    }

    public void ClearScoreAdd4()
    {
        ScoreManager.bestBallY += bonasuscore;
        saisyutokuten.text = ("最終得点 :" + ScoreManager.bestBallY.ToString());

    }

    public void saisyuutokuten()
    {
        saisyutokuten.text = ("最終得点 :" + ScoreManager.bestBallY.ToString());
    }


}
