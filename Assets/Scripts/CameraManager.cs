using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("First", true);
        anim.SetFloat("BallPos", 1);
    }

    private void Update()
    {
        Vector3 ballPos = Ball.transform.position;

        if (ballPos.y >= 26f)
        {
            anim.SetFloat("BallPos", 2.5f);
        }
        else if (ballPos.y >= 6)
        {
            anim.SetFloat("BallPos", 2);
        }
        else if (ballPos.y >= -5)
        {
            anim.SetFloat("BallPos", 1);
        }
        else if (ballPos.y >= -13.84f)
        {
            anim.SetFloat("BallPos", -1);
        }
        else
        {
            anim.SetFloat("BallPos", -1.5f);
        }
    }
}
