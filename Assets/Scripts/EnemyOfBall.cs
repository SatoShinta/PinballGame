using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOfBall : MonoBehaviour
{
    [SerializeField, Header("ìGÉ{Å[Éã")] GameObject madeOfEnemy;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(madeOfEnemy,transform.position, Quaternion.identity);
            Invoke("EnemyBall", 0.2f);
        }
    }

    public void EnemyBall()
    {
        Destroy(gameObject);
    }
}
