using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOfBall : MonoBehaviour
{
    [SerializeField, Header("ìGÉ{Å[Éã")] GameObject madeOfEnemy;

    int hitCounter;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(madeOfEnemy,transform.position, Quaternion.identity);
            Invoke("EnemyBall", 0.2f);
        }

        if (collision.gameObject.CompareTag("EnemyBall"))
        {
            hitCounter++;
            if(hitCounter == 3)
            {
                EnemyBall();
            }
        }
    }

    public void EnemyBall()
    {
        Destroy(gameObject);
    }
}
