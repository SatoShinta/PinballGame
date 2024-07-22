using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] LeftFlipper;
    [SerializeField] GameObject[] RightFlipper;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject[] taihou;
    [SerializeField] GameObject yuka;
    [SerializeField] float torqueForce;

    public bool gameOver;

    Rigidbody2D[] leftRig;
    Rigidbody2D[] rightRig;
    Rigidbody2D ballRig;


    void Start()
    {
        gameOver = false;

        LeftFlipper = GameObject.FindGameObjectsWithTag("Left");
        RightFlipper = GameObject.FindGameObjectsWithTag("Right");
        ballRig = ball.GetComponent<Rigidbody2D>();

        leftRig = new Rigidbody2D[LeftFlipper.Length];
        rightRig = new Rigidbody2D[RightFlipper.Length];

        for (int i = 0; i < LeftFlipper.Length; i++)
        {
            leftRig[i] = LeftFlipper[i].GetComponent<Rigidbody2D>();
        }

        for (int i = 0; i < RightFlipper.Length; i++)
        {
            rightRig[i] = RightFlipper[i].GetComponent<Rigidbody2D>();
        }



    }

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            AddTorque(leftRig, torqueForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
            AddTorque(rightRig, -torqueForce);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            AddTorque(leftRig, torqueForce);
            AddTorque(rightRig, -torqueForce);
            Invoke("GameStart", 0.3f);
        }

        if (ball.transform.position.y <= -26f)
        {
            gameOver = true;
        }



    }



    void AddTorque(Rigidbody2D[] rigits, float force)
    {
        foreach (Rigidbody2D rigit in rigits)
        {
            rigit.AddTorque(force);
        }
    }

    public void GameStart()
    {
        Destroy(yuka);
    }
}
