using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] Text nowBallYText;
    [SerializeField] Text bestBallYText;
    [SerializeField] Text bestScoreText;
    [SerializeField] Text ResultScoreText;
    [SerializeField] GameManager manager;

    bool scoreUpdate = false;
    int ballPosY;
    int bestPosy;
    int score;

    //�V�[�����܂����ł������z�����l
    public static int bestBallY;
    public static int extraScore;


    private void Start()
    {
        //�ǉ����_�̏������s�����ǂ����̃t���O
        scoreUpdate = false ;
        Debug.Log(score);
        ballPosY = 0;
        score = 0;

        //�����������H�i�ł��Ă邩�ǂ����킩��Ȃ��j
        bestScoreText.text = ("�ǉ����_  " + score.ToString());
        bestBallYText.text = ("�ō��L�^  " + bestBallY.ToString());
        
        //GameManager���Z�b�g����
        manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Ball != null)
        {
            nowBallYText.text = ("���݈ʒu  " + ballPosY.ToString());
            ballPosY = Mathf.RoundToInt(Ball.transform.position.y);
            if (ballPosY > bestPosy)
            {
                BestBallPosUpdate();
            }

            if (manager != null && manager.gameOver == true)
            {
                ballPosY = 0;
            }

            if (!scoreUpdate)
            {
                if (bestBallY >= 100)
                {
                    ScoreUpdate(100);
                    scoreUpdate = true;
                }
                else if (bestBallY >= 200)
                {
                    ScoreUpdate(200);
                    scoreUpdate = true;
                }
            }

        }

    }

    public void ScoreUpdate(int scr)
    {
        score += scr;
        extraScore += score;
        bestScoreText.text = ("�ǉ����_  " + score.ToString());
        ResultScoreText.text = ("�ǉ����_�@" + extraScore.ToString());
    }


    void BestBallPosUpdate()
    {
        if (Ball != null)
        {
            bestPosy = ballPosY;

            if (bestPosy > bestBallY)
            {
                bestBallY = bestPosy;
                bestBallYText.text = ("�ō��L�^  " + bestBallY.ToString());
            }
        }

    }
    public void ResultScore()
    {
        bestBallY += extraScore;
        bestBallYText.text = ("�ŏI���_ " + bestBallY.ToString());
    }
    public void Result()
    {
        bestBallYText.text = ("�ō��L�^  " + bestBallY.ToString());
        ResultScoreText.text = ("�ǉ����_�@" + extraScore.ToString());
    }
}
