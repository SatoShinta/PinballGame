using Unity.VisualScripting;
using UnityEngine;

public class BallCtr : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] taihou;
    [SerializeField] ScoreManager scoreManager;

    Rigidbody2D rigidbody2;
    Collider2D taihoucol;


    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("taihou"))
        {
            rigidbody2.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            scoreManager.ScoreUpdate(1);
        }
        else if (collision.gameObject.CompareTag("Enemy2"))
        {
            scoreManager.ScoreUpdate(2);
        }

    }
}
