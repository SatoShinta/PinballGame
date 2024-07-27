using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOfBall : MonoBehaviour
{
    [SerializeField, Header("�G�{�[��")] GameObject madeOfEnemy;

    //�{�[��������������
    int hitCounter;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //ball�ɓ���������
        if (collision.gameObject.CompareTag("Ball"))
        {
            //�G����{�[���𐶐����A���̌�G��j�󂷂�
            Instantiate(madeOfEnemy,transform.position, Quaternion.identity);
            Invoke("EnemyBall", 0.2f);
        }

        //�G���琶�������{�[���ɓ���������
        if (collision.gameObject.CompareTag("EnemyBall"))
        {
            //hitCounter�𑝂₵
            hitCounter++;
            //�q�b�g�J�E���^�[���R�ɂȂ�����
            if(hitCounter == 3)
            {
                //���̃I�u�W�F�N�g��j�󂷂�
                EnemyBall();
            }
        }
    }

    public void EnemyBall()
    {
        Destroy(gameObject);
    }
}
