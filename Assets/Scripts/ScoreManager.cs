using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] Text nowBallYText;
    [SerializeField] Text bestBallYText;
    [SerializeField] Text bestScoreText;
    [SerializeField] GameManager manager;

    bool scoreUpdate = false;
    int ballPosY;
    int bestPosy;
    public static int bestBallY;
    public static int score;


    private void Start()
    {
        ballPosY = 0;
        score = 0;

        bestScoreText.text =("追加得点  " + score.ToString());
        bestBallYText.text =("最高記録  " + bestBallY.ToString());
        manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Ball != null)
        {
            nowBallYText.text =("現在位置  " + ballPosY.ToString());
            ballPosY = Mathf.RoundToInt(Ball.transform.position.y);
            if (ballPosY > bestPosy)
            {
                BestBallPosUpdate();
            }

            if (manager != null && manager.gameOver == true)
            {
                ballPosY = 0;
            }

            if(!scoreUpdate)
            {
                if(bestBallY >= 100)
                {
                    ScoreUpdate(100);
                    scoreUpdate = true;
                }
                else if(bestBallY >= 200)
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
        bestScoreText.text =("追加得点  " + score.ToString());
        Debug.Log(score);
    }


    void BestBallPosUpdate()
    {
        if (Ball != null)
        {
            bestPosy = ballPosY;

            if (bestPosy > bestBallY)
            {
                bestBallY = bestPosy;
                bestBallYText.text =("最高記録  " + bestBallY.ToString());
            }
        }

    }
    public void ResultScore()
    {
        bestBallY += score;
        bestBallYText.text =("最終得点 " + bestBallY.ToString());
        Debug.Log(bestBallY);
    }
}
