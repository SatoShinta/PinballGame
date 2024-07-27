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
        bestBallY = 0 ;
        extraScore = 0 ;
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
        //����Ball�ɃI�u�W�F�N�g���A�^�b�`����Ă�����
        if (Ball != null)
        {
            //���݈ʒu�̃e�L�X�g���X�V
            nowBallYText.text = ("���݈ʒu  " + ballPosY.ToString());
            //Ball�̈ʒu��float�^����int�^�ɕϊ����đ��
            ballPosY = Mathf.RoundToInt(Ball.transform.position.y);

            //�{�[���̈ʒu���ō��n�_���傫���Ȃ�����
            if (ballPosY > bestPosy)
            {
                //���̃��\�b�h�����s����
                BestBallPosUpdate();
            }

            //gamemanager�̃Q�[���I�[�o�[�t���O��true�̎�
            if (manager != null && manager.gameOver == true)
            {
                //���݈ʒu���O�ɂ���
                ballPosY = 0;
            }

            //scoreUpdate�t���O��false�̎�
            if (!scoreUpdate)
            {
                //�ō��n�_��100���傫���Ȃ�����
                if (bestBallY >= 100)
                {
                    //�ǉ����_��100��ǉ����AscoreUpdate�t���O��true�ɂ���
                    ScoreUpdate(100);
                    scoreUpdate = true;
                }
                //�ō��n�_��200���傫���Ȃ�����
                else if (bestBallY >= 200 && scoreUpdate == true)
                {
                    //�ǉ����_��200��ǉ�����
                    ScoreUpdate(200);
                    scoreUpdate = true;
                }
            }

        }

    }

    //�ǉ����_�̏��������郁�\�b�h
    public void ScoreUpdate(int scr)
    {
        //score�Ɉ�����������
        score += scr;
        //extraScore��score�̒l��������
        extraScore += score;
        //�w�肵���e�L�X�g��score��extraScore�̒l������
        bestScoreText.text = ("�ǉ����_  " + score.ToString());
        ResultScoreText.text = ("�ǉ����_�@" + extraScore.ToString());
    }


    //Ball�̍ō��n�_���X�V���郁�\�b�h
    void BestBallPosUpdate()
    {
        //Ball�ɃI�u�W�F�N�g���A�^�b�`����Ă���Ƃ�
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
