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

    //�V�[�����܂����ł������z�����l
    public static int bestBallY;
    public static int extraScore;

    // �X�R�A��ǉ����邵�����l�̔z��
    private int[] thresholds = { 100, 200, 300 };
    private int thresholdIndex = 0;

    // �������l�𒴂������ǂ����̃t���O
    private bool[] hasScored;


    public void Awake()
    {
        extraScore = 0;
        bestBallY = 0;
    }

    private void Start()
    {

        if (nowBallYText == null) Debug.LogError("nowBallYText���A�T�C������Ă��܂���B");
        if (bestBallYText == null) Debug.LogError("bestBallYText���A�T�C������Ă��܂���B");
        if (bestScoreText == null) Debug.LogError("bestScoreText���A�T�C������Ă��܂���B");

        // GameManager���Z�b�g����
        manager = FindObjectOfType<GameManager>();
        if (manager == null)
        {
            Debug.LogError("GameManager���V�[���Ɍ�����܂���B");
        }

        ballPosY = 0;
        score = 0;

        bestScoreText.text = ("�ǉ����_  " + score.ToString());
        bestBallYText.text = ("�ō��L�^  " + bestBallY.ToString());

        // �t���O�̏�����
        hasScored = new bool[thresholds.Length];
    }

    private void Update()
    {
        Debug.Log(extraScore);
        if (Ball != null)
        {
            ballPosY = Mathf.RoundToInt(Ball.transform.position.y);
            //�{�[���̌��݈ʒu�̍X�V���s��
            nowBallYText.text = ("���݈ʒu  " + ballPosY.ToString());

            //�{�[���̈ʒu���ō��n�_���傫���Ȃ�����
            if (ballPosY > bestPosy)
            {
                BestBallPosUpdate();
            }

            //gamemanager�̃Q�[���I�[�o�[�t���O��true�̎�
            if (manager != null && manager.gameOver == true)
            {
                //���݈ʒu���O�ɂ���
                ballPosY = 0;
            }

            for (int i = thresholdIndex; i < thresholds.Length; i++)
            {
                //�{�[���̈ʒu���������l�𒴂��āA���̒l�����ł��ʂ��Ă��Ȃ�������
                if (ballPosY > thresholds[i] && !hasScored[i])
                {
                    //�X�R�A���A�b�v�f�[�g���āA���̍�����ʂ������Ƃ��L�^����
                    ScoreUpdate(thresholds[i]);
                    // �X�R�A��ǉ��������Ƃ��L�^
                    hasScored[i] = true;
                }
            }
        }
        else
        {
            Debug.LogError("Ball�I�u�W�F�N�g���V�[���Ɍ�����܂���B");
        }
    }

    //�ǉ����_�̏��������郁�\�b�h
    public void ScoreUpdate(int scr)
    {
        score += scr;
        extraScore += score;
        bestScoreText.text = ("�ǉ����_  " + extraScore.ToString());
    }

    //Ball�̍ō��n�_���X�V���郁�\�b�h
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
}