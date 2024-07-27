using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOfBall : MonoBehaviour
{
    [SerializeField, Header("敵ボール")] GameObject madeOfEnemy;

    //ボールが当たった数
    int hitCounter;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //ballに当たったら
        if (collision.gameObject.CompareTag("Ball"))
        {
            //敵からボールを生成し、その後敵を破壊する
            Instantiate(madeOfEnemy,transform.position, Quaternion.identity);
            Invoke("EnemyBall", 0.2f);
        }

        //敵から生成したボールに当たったら
        if (collision.gameObject.CompareTag("EnemyBall"))
        {
            //hitCounterを増やし
            hitCounter++;
            //ヒットカウンターが３になったら
            if(hitCounter == 3)
            {
                //このオブジェクトを破壊する
                EnemyBall();
            }
        }
    }

    public void EnemyBall()
    {
        Destroy(gameObject);
    }
}
