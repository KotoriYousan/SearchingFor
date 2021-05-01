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


    public void LockPlayer()
    {
        anim.SetBool("isWalking", false);
        anim.SetBool("isWalkingBack", false);
        anim.SetBool("isWalkingRight", false);
        anim.SetBool("isWalkingLeft", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isRunningBack", false);
        anim.SetBool("isRunningRight", false);
        anim.SetBool("isRunningLeft", false);

        Player.GetComponent<FirstPersonDrifter>().enabled = false;
    }

    public void UnlockPlayer()
    {
        Player.GetComponent<FirstPersonDrifter>().enabled = true;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //    Application.Quit();

        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
        {
            LockPlayer();
        }
        else {

            UnlockPlayer();

            bool moving = false;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isRunningBack", false);
                anim.SetBool("isRunningRight", false);
                anim.SetBool("isRunningLeft", false);

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    Debug.Log("running");

                    anim.SetBool("isWalking", false);
                    anim.SetBool("isWalkingBack", false);
                    anim.SetBool("isWalkingRight", false);
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isRunning", true);
                    anim.SetBool("isRunningBack", false);
                    anim.SetBool("isRunningRight", false);
                    anim.SetBool("isRunningLeft", false);
                }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isWalkingRight", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalkingLeft", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isRunningBack", false);
                anim.SetBool("isRunningRight", false);
                anim.SetBool("isRunningLeft", false);

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    Debug.Log("running");

                    anim.SetBool("isWalking", false);
                    anim.SetBool("isWalkingBack", false);
                    anim.SetBool("isWalkingRight", false);
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isRunningBack", false);
                    anim.SetBool("isRunningRight", true);
                    anim.SetBool("isRunningLeft", false);
                }

            }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("isWalkingLeft", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingBack", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isRunningBack", false);
                anim.SetBool("isRunningRight", false);
                anim.SetBool("isRunningLeft", false);

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    Debug.Log("running");

                    anim.SetBool("isWalking", false);
                    anim.SetBool("isWalkingBack", false);
                    anim.SetBool("isWalkingRight", false);
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isRunningBack", false);
                    anim.SetBool("isRunningRight", false);
                    anim.SetBool("isRunningLeft", true);
                }

            }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isWalkingBack", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isRunningBack", false);
                anim.SetBool("isRunningRight", false);
                anim.SetBool("isRunningLeft", false);

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    Debug.Log("running");

                    anim.SetBool("isWalking", false);
                    anim.SetBool("isWalkingBack", false);
                    anim.SetBool("isWalkingRight", false);
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isRunningBack", true);
                    anim.SetBool("isRunningRight", false);
                    anim.SetBool("isRunningLeft", false);
                }

            }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isRunningBack", false);
                anim.SetBool("isRunningRight", false);
                anim.SetBool("isRunningLeft", false);
            }


        }
    }
}
