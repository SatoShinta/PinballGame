using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Animator anim;

    

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("First", true);
    }

}
