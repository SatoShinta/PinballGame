using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScore : MonoBehaviour
{
    [SerializeField,Header("�ŏI���_")] Text saisyutokuten;
    [SerializeField, Header("�ǉ����_")] Text tuikatokuten;
    [SerializeField, Header("�N���A�^�C�����_")] Text kuriataimutokuten;
    [SerializeField, Header("�G���j���_")] Text tekigekihatokuten;
    [SerializeField, Header("�N���A���Ă���Ă��肪�Ƃ��e�L�X�g")] Text arigatoutokuten;
    [SerializeField, Header("�N���A���Ă���Ă��肪�Ƃ����_")] Text arigatousukoa;

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
        saisyutokuten.text = ("�ŏI���_ : " + ScoreManager.bestBallY.ToString());
        tuikatokuten.text = ("�ǉ����_ : " + ScoreManager.extraScore.ToString());
        kuriataimutokuten.text = ("�N���A�^�C���{�[�i�X : " + Mathf.CeilToInt(GameManager.gameOverTimer).ToString());
        tekigekihatokuten.text = ("�G���j�{�[�i�X : " + BallCtr.destroyCounter2.ToString());
        arigatoutokuten.text = ("�Ō�܂ŗV��ł���Ă��肪�Ƃ��I");
        arigatousukoa.text = (bonasuscore.ToString());
    }

    public void ClearScoreAdd1()
    {
        ScoreManager.bestBallY += ScoreManager.extraScore;
        saisyutokuten.text = ("�ŏI���_ :" + ScoreManager.bestBallY.ToString());

    }

    public void ClearScoreAdd2()
    {
        ScoreManager.bestBallY += (int)GameManager.gameOverTimer;
        saisyutokuten.text = ("�ŏI���_ :" + ScoreManager.bestBallY.ToString());

    }

    public void ClearScoreAdd3()
    {
        ScoreManager.bestBallY += BallCtr.destroyCounter2;
        saisyutokuten.text = ("�ŏI���_ :" + ScoreManager.bestBallY.ToString());

    }

    public void ClearScoreAdd4()
    {
        ScoreManager.bestBallY += bonasuscore;
        saisyutokuten.text = ("�ŏI���_ :" + ScoreManager.bestBallY.ToString());

    }

    public void saisyuutokuten()
    {
        saisyutokuten.text = ("�ŏI���_ :" + ScoreManager.bestBallY.ToString());
    }


}
