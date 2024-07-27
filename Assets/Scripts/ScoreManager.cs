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

    //シーンをまたいでも持ち越される値
    public static int bestBallY;
    public static int extraScore;


    private void Start()
    {
        //追加得点の処理を行うかどうかのフラグ
        scoreUpdate = false ;
        Debug.Log(score);
        bestBallY = 0 ;
        extraScore = 0 ;
        ballPosY = 0;
        score = 0;

        //初期化処理？（できてるかどうかわからない）
        bestScoreText.text = ("追加得点  " + score.ToString());
        bestBallYText.text = ("最高記録  " + bestBallY.ToString());
        
        //GameManagerをセットする
        manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        //もしBallにオブジェクトがアタッチされていたら
        if (Ball != null)
        {
            //現在位置のテキストを更新
            nowBallYText.text = ("現在位置  " + ballPosY.ToString());
            //Ballの位置をfloat型からint型に変換して代入
            ballPosY = Mathf.RoundToInt(Ball.transform.position.y);

            //ボールの位置が最高地点より大きくなったら
            if (ballPosY > bestPosy)
            {
                //このメソッドを実行する
                BestBallPosUpdate();
            }

            //gamemanagerのゲームオーバーフラグがtrueの時
            if (manager != null && manager.gameOver == true)
            {
                //現在位置を０にする
                ballPosY = 0;
            }

            //scoreUpdateフラグがfalseの時
            if (!scoreUpdate)
            {
                //最高地点が100より大きくなったら
                if (bestBallY >= 100)
                {
                    //追加得点に100を追加し、scoreUpdateフラグをtrueにする
                    ScoreUpdate(100);
                    scoreUpdate = true;
                }
                //最高地点が200より大きくなったら
                else if (bestBallY >= 200 && scoreUpdate == true)
                {
                    //追加得点に200を追加する
                    ScoreUpdate(200);
                    scoreUpdate = true;
                }
            }

        }

    }

    //追加得点の処理をするメソッド
    public void ScoreUpdate(int scr)
    {
        //scoreに引数を代入する
        score += scr;
        //extraScoreにscoreの値を代入する
        extraScore += score;
        //指定したテキストにscoreとextraScoreの値を入れる
        bestScoreText.text = ("追加得点  " + score.ToString());
        ResultScoreText.text = ("追加得点　" + extraScore.ToString());
    }


    //Ballの最高地点を更新するメソッド
    void BestBallPosUpdate()
    {
        //Ballにオブジェクトがアタッチされているとき
        if (Ball != null)
        {
            bestPosy = ballPosY;

            if (bestPosy > bestBallY)
            {
                bestBallY = bestPosy;
                bestBallYText.text = ("最高記録  " + bestBallY.ToString());
            }
        }

    }
    public void ResultScore()
    {
        bestBallY += extraScore;
        bestBallYText.text = ("最終得点 " + bestBallY.ToString());
    }
    public void Result()
    {
        bestBallYText.text = ("最高記録  " + bestBallY.ToString());
        ResultScoreText.text = ("追加得点　" + extraScore.ToString());
    }
}
