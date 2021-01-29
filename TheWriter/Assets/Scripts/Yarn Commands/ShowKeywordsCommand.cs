using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ShowKeywordsCommand : MonoBehaviour
{
    [YarnCommand("show_keywords")]
    public void Switch_ordinary()
    {
        Debug.Log("show kws");
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
