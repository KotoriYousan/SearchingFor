using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class VNCommands : MonoBehaviour
{
    [YarnCommand("Show")]
    public void ShowObj()
    {
        Debug.Log("yarn command run");

        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //gameObject.SetActive(true);
    }

    [YarnCommand("Hide")]
    public void HideObj()
    {
        Debug.Log("yarn command run");

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //gameObject.SetActive(false);
    }


    public Sprite gin, mian;
    [YarnCommand("SetAvatar")]
    public void SetAvatar(string chname)
    {
        Debug.Log("yarn command run");
        

        if(chname == "gin")
        {
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Image>().sprite = gin;
            //gameObject.GetComponent<SpriteRenderer>().sprite = gin;
        }else if(chname == "mian")
        {
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Image>().sprite = mian;
            //gameObject.GetComponent<SpriteRenderer>().sprite = mian;
        }else if(chname == "none")
        {
            gameObject.GetComponent<Image>().enabled = false;
            //gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

}
