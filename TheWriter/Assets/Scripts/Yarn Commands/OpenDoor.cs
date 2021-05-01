using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class OpenDoor : MonoBehaviour
{

    [YarnCommand("open_door")]
    public void Open_Door()
    {
        Debug.Log("yarn command run");

        Animator animator = gameObject.GetComponent<Animator>();
        animator.Play("Base Layer.opendoor");

        //Animation anim = gameObject.GetComponent<Animation>();
        //anim.Play("open door");
    }

    [YarnCommand("SetActive")]
    public void SetObjActive(string bl)
    {
        Debug.Log("yarn command run");

        if(bl == "true")
        {
            gameObject.SetActive(true);
        }
        else if(bl == "false")
        {
            gameObject.SetActive(false);
        }
        

    }

}
