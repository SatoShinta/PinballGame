using UnityEngine;

public class TaihouCtr : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Invoke("DestroyTaihou", 1f);
        }
    }


    void DestroyTaihou() { Destroy(gameObject); }
}
