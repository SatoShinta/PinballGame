using System.Collections;
using UnityEngine;

public class Enemy2_Bullet : MonoBehaviour
{
    [SerializeField] GameObject mazzle;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField, Header("”­ŽË‘¬“x")] float bulletSpeed;
    [SerializeField, Header("”­ŽËŠÔŠu")] float fireBulletSpeed;

   
    IEnumerator FireBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireBulletSpeed);
            GameObject bullet = Instantiate(bulletPrefab,mazzle.transform.position, mazzle.transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = -mazzle.transform.up * bulletSpeed;
            }
        }
    }
}
