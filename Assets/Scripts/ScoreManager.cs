using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] Text nowBallYText;
    [SerializeField] Text bestBallYText;
    [SerializeField] Text bestScoreText;
    [SerializeField] GameManager manager;

    private int ballPosY;
    private int bestPosy;
    private int score;

    //シーンをまたいでも持ち越される値
    public static int bestBallY;
    public static int extraScore;

    // スコアを追加するしきい値の配列
    private int[] thresholds = { 100, 200, 300 };
    private int thresholdIndex = 0;

    // しきい値を超えたかどうかのフラグ
    private bool[] hasScored;


    public void Awake()
    {
        extraScore = 0;
        bestBallY = 0;
    }

    private void Start()
    {

        if (nowBallYText == null) Debug.LogError("nowBallYTextがアサインされていません。");
        if (bestBallYText == null) Debug.LogError("bestBallYTextがアサインされていません。");
        if (bestScoreText == null) Debug.LogError("bestScoreTextがアサインされていません。");

        // GameManagerをセットする
        manager = FindObjectOfType<GameManager>();
        if (manager == null)
        {
            Debug.LogError("GameManagerがシーンに見つかりません。");
        }

        ballPosY = 0;
        score = 0;

        bestScoreText.text = ("追加得点  " + score.ToString());
        bestBallYText.text = ("最高記録  " + bestBallY.ToString());

        // フラグの初期化
        hasScored = new bool[thresholds.Length];
    }

    private void Update()
    {
        Debug.Log(extraScore);
        if (Ball != null)
        {
            ballPosY = Mathf.RoundToInt(Ball.transform.position.y);
            //ボールの現在位置の更新を行う
            nowBallYText.text = ("現在位置  " + ballPosY.ToString());

            //ボールの位置が最高地点より大きくなったら
            if (ballPosY > bestPosy)
            {
                BestBallPosUpdate();
            }

            //gamemanagerのゲームオーバーフラグがtrueの時
            if (manager != null && manager.gameOver == true)
            {
                //現在位置を０にする
                ballPosY = 0;
            }

            for (int i = thresholdIndex; i < thresholds.Length; i++)
            {
                //ボールの位置がしきい値を超えて、その値を一回でも通っていなかったら
                if (ballPosY > thresholds[i] && !hasScored[i])
                {
                    //スコアをアップデートして、その高さを通ったことを記録する
                    ScoreUpdate(thresholds[i]);
                    // スコアを追加したことを記録
                    hasScored[i] = true;
                }
            }
        }
        else
        {
            Debug.LogError("Ballオブジェクトがシーンに見つかりません。");
        }
    }

    //追加得点の処理をするメソッド
    public void ScoreUpdate(int scr)
    {
        score += scr;
        extraScore += score;
        bestScoreText.text = ("追加得点  " + extraScore.ToString());
    }

    //Ballの最高地点を更新するメソッド
    void BestBallPosUpdate()
    {
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
}