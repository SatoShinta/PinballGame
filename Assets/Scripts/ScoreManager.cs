using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] Text nowBallYText;
    [SerializeField] Text bestBallYText;
    [SerializeField] GameManager manager;

    float ballPosY;
    float bestPosy;
    public static float bestBallY;


    private void Start()
    {
        ballPosY = 0;
       // bestPosy = 0;
        bestBallYText.text = bestBallY.ToString();
        manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(Ball != null )
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
        if(Ball != null)
        {
            bestPosy = ballPosY;

            if (bestPosy > bestBallY)
            {
                bestBallY = bestPosy;
                bestBallYText.text = bestBallY.ToString();
            }
        }
      
    }
}
