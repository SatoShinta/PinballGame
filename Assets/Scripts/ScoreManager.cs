using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] Text nowBallYText;
    [SerializeField] Text bestBallYText;
    [SerializeField] Text bestScoreText;
    [SerializeField] GameManager manager;

    float ballPosY;
    float bestPosy;
    public static float bestBallY;
    public static float score;


    private void Start()
    {
        bestBallY = 0;
        score = 10;
        ballPosY = 0;
        // bestPosy = 0;

        bestScoreText.text = score.ToString();
        bestBallYText.text = bestBallY.ToString();
        manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Ball != null)
        {
            nowBallYText.text = ballPosY.ToString();
            ballPosY = Ball.transform.position.y;
            if (ballPosY > bestPosy)
            {
                BestBallPosUpdate();
            }

            if (manager != null && manager.gameOver == true)
            {
                ballPosY = 0;
            }
        }

    }

    void BestBallPosUpdate()
    {
        if (Ball != null)
        {
            bestPosy = ballPosY;

            if (bestPosy > bestBallY)
            {
                bestBallY = bestPosy;
                bestBallYText.text = bestBallY.ToString();
            }
        }

    }
    public void ResultScore()
    {
        bestBallY += score;
        bestBallYText.text = bestBallY.ToString() ;
        Debug.Log(bestBallY);
    }
}
