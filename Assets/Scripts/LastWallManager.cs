using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LastWallManager : MonoBehaviour
{
    int counter = 0;
    Animator animator;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "Player")
        {
            counter++;
        }
    }

    private void Awake()
    {
        counter = 0;
    }

    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("HitCounter", counter);

        if(counter >= 5)
        {
            Destroy(gameObject);
        }
    }
}
