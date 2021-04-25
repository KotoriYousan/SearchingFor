using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerAni : MonoBehaviour
{

    public GameObject Player;


    private Animator anim;
    //public Transform roadAxis;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        //Cursor.visible = false;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //    Application.Quit();

        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", false);
            anim.SetBool("isRunning", false);

            Player.GetComponent<FirstPersonDrifter>().enabled = false;
        }
        else {

            Player.GetComponent<FirstPersonDrifter>().enabled = true;

            bool moving = false;
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", false);
                anim.SetBool("isRunning", false);

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    Debug.Log("running");

                    anim.SetBool("isWalking", false);
                    anim.SetBool("isWalkingBack", false);
                    anim.SetBool("isWalkingRight", false);
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isRunning", true);
                }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalkingRight", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalkingLeft", false);
                anim.SetBool("isRunning", false);
            }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalkingLeft", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingBack", false);
                anim.SetBool("isRunning", false);
            }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalkingBack", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", false);
                anim.SetBool("isRunning", false);
            }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", false);
                anim.SetBool("isRunning", false);
            }


        }
    }
}
