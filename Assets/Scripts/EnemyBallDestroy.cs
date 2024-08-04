using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallDestroy : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -14)
        {
            Destroy(gameObject);
        }
    }
}
