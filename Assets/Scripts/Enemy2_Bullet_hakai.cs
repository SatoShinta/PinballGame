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
            // “–‚½‚Á‚½Flipper‚ğ”ñ•\¦‚É‚·‚é
            collision.gameObject.SetActive(false);

            // ’e©g‚ğ”j‰ó‚·‚é
            Destroy(gameObject);

           
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
