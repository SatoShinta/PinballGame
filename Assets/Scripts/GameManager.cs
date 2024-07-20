using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject LeftFlipper;
    [SerializeField] GameObject RightFlipper;
    [SerializeField] float torqueForce;

    Rigidbody2D leftRig;
    Rigidbody2D rightRig;


    void Start()
    {
        leftRig = LeftFlipper.GetComponent<Rigidbody2D>();
        rightRig = RightFlipper.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddTorque(leftRig, torqueForce);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AddTorque(rightRig, -torqueForce);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddTorque(leftRig, torqueForce);
            AddTorque(rightRig, -torqueForce);

        }
    }

    void AddTorque(Rigidbody2D rigit, float force)
    {
        rigit.AddTorque(force);
    }
}
