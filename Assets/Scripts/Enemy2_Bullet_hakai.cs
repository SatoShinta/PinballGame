using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2_Bullet_hakai : MonoBehaviour
{
    public float respawnTimer = 2f;
    public List<GameObject> hitFlippers = new List<GameObject>();


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag is "Left" or "Right")
        {
            // 当たったFlipperを非表示にする
            collision.gameObject.SetActive(false);

            // 弾自身を破壊する
            Destroy(gameObject);

            // Flipperを復活させる
            Invoke("RestoreFlipper", respawnTimer );

            //衝突したフリッパーをリストに追加する
            hitFlippers.Add( collision.gameObject );
        }

    }

   /* public void RestoreFlipper()
    {
       foreach(GameObject flipper in hitFlippers)
        {
            flipper.SetActive(true);
        }
       hitFlippers.Clear();
    }*/
}
