using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField, Header("�G����")] List<GameObject> enemys1;
    [SerializeField, Header("1�w�o���ʒu")] List<GameObject> spownpos;


    public void Start()
    {
        foreach(GameObject enemy in enemys1)
        {
            Rigidbody2D enemyRig = enemy.GetComponent<Rigidbody2D>();
            Collider2D enemyCol = enemy.GetComponent<Collider2D>();
        }

        EnemyInstantiate1();
        
    }



    public void EnemyInstantiate1()
    {
        for(int i = 0; i < spownpos.Count; i++)
        {
            Instantiate(enemys1[0], spownpos[i].transform);
        }
    }

   
}
