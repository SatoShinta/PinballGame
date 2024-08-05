using System.Collections;
using UnityEngine;

public class Enemy2_Bullet : MonoBehaviour
{
    [SerializeField] GameObject mazzle;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField, Header("”­ŽË‘¬“x")] float bulletSpeed;
    [SerializeField, Header("”­ŽËŠÔŠu")] float fireBulletSpeed;

    private void Start()
    {
        StartCoroutine(FireBullet());
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flipper"))
        {
            collision.gameObject.SetActive(false);
        }
    }


    IEnumerator FireBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireBulletSpeed);
            GameObject bullet = Instantiate(bulletPrefab, mazzle.transform.position, bulletPrefab.transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = -mazzle.transform.up * bulletSpeed;
            }
        }
    }

   
}
