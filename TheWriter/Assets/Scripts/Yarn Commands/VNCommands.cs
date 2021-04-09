using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class VNCommands : MonoBehaviour
{
    [YarnCommand("Show")]
    public void ShowObj()
    {
        Debug.Log("yarn command run");

        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    [YarnCommand("Hide")]
    public void HideObj()
    {
        Debug.Log("yarn command run");

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

}
