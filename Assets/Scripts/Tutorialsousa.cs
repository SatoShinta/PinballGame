using UnityEngine;

public class Tutorialsousa : MonoBehaviour
{

    [SerializeField] GameObject LeftFlipper;
    [SerializeField] GameObject RightFlipper;
    [SerializeField] float torqueForce;

    Rigidbody2D leftRig;
    Rigidbody2D rightRig;
    // Start is called before the first frame update
    void Start()
    {
        leftRig = LeftFlipper.GetComponent<Rigidbody2D>();
        rightRig = RightFlipper.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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

        }
    }

    void AddTorque(Rigidbody2D rigit, float force)
    {

        rigit.AddTorque(force);

    }
}
