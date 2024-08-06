using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallDestroy : MonoBehaviour
{
    public float destroyTimer = 0;

    // Update is called once per frame
    void Update()
    {
        destroyTimer += Time.deltaTime;
        if (this.transform.position.y <= -14 || destroyTimer >= 10f)
        {
            Destroy(gameObject);
        }
    }
}
