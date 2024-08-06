using Unity.VisualScripting;
using UnityEngine;

public class BallCtr : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] taihou;
    [SerializeField] GameObject enemy_3_spawn;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] EnemyManager EnemyManager;

    Rigidbody2D rigidbody2;
    Collider2D taihoucol;
    Animator animator;
    public int f_counter1;
    public int destroyCounter;


    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        f_counter1 = 0;
        destroyCounter = 0;
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if(destroyCounter >= 5)
        {
            gameManager.gameOverTimer += 3f;
            destroyCounter = 0;
        }
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
                destroyCounter++;
                break;
            case "Enemy2":
                scoreManager.ScoreUpdate(2);
                destroyCounter++;
                break;
            case "Enemy3":
                scoreManager.ScoreUpdate(3);
                destroyCounter++;
                break;
            default:
                break;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaa");
        if (collision.gameObject.Equals(enemy_3_spawn) && EnemyManager.enemy_3_spawn == false)
        {
            EnemyManager.enemy_3_spawn = true;
            EnemyManager.EnemyInstantiate3();
            f_counter1 = 1;
        }

        if (collision.gameObject.CompareTag("Clear"))
        {
            //rigidbody2.velocity = Vector2.up * 2;
            //rigidbody2.gravityScale = -10;
            animator.SetBool("Clear", true);
            gameManager.timerStart = false;
        }
    }

}
