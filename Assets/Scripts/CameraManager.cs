using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    Animator anim;
    Vector2 ballPos;

    private void Start()
    {
        Ball.GetComponent<Transform>();
        anim = GetComponent<Animator>();
        anim.SetBool("First", true);
        anim.SetFloat("BallPos", 1);
    }

    private void Update()
    {
       // Debug.Log(ballPos);
        ballPos = Ball.transform.position;

        if (ballPos != null && ballPos.y >= -5 && ballPos.y <= 4)
        {
            anim.SetFloat("BallPos", 1);
        }

        if (ballPos != null && ballPos.y <= -5 && ballPos.y >= -13.84f)
        {
            anim.SetFloat("BallPos", -1);
        }

        if (ballPos != null && ballPos.y >= 6)
        {
            anim.SetFloat("BallPos", 2);
        }

        if(ballPos != null && ballPos.y <= -13.85f)
        {
            anim.SetFloat("BallPos", -1.5f);
        }
    }
}
