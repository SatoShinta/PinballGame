using Unity.VisualScripting;
using UnityEngine;

public class BallCtr : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] taihou;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] EnemyManager EnemyManager;

    Rigidbody2D rigidbody2;
    Collider2D taihoucol;


    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        //ëÂñCÇ∆ìGÇ…ìñÇΩÇ¡ÇΩéûÇÃèàóù
        switch (collision.gameObject.tag)
        {
            case "taihou":
                rigidbody2.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                break;
            case "Enemy":
                scoreManager.ScoreUpdate(1);
                break;
            case "Enemy2":
                scoreManager.ScoreUpdate(2);
                break;
            case "Enemy3":
                scoreManager.ScoreUpdate(3);
                break;
            default:
                break;
        }
        if (collision.gameObject.Equals(EnemyManager.enemy3action))
        {
           EnemyManager.enemy_3_spawn = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(EnemyManager.enemy3action))
        {
            EnemyManager.enemy_3_spawn = true;
        }
    }

}
