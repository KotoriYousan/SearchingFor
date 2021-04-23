using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
    private Animator anim;
    //public Transform roadAxis;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        bool moving = false;
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalkingRight", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalkingLeft", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalkingLeft", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingBack", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalkingBack", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", false);
        }
    }
}
