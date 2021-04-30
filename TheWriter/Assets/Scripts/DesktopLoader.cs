using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesktopLoader : MonoBehaviour
{
    
    public InputField inputField;

    public GameObject NovelSite;

    private void Awake()
    {
        NovelSite.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void OpenNovelSitePage()
    {
        NovelSite.SetActive(true);
    }

    public void CloseNovelSitePage()
    {
        NovelSite.SetActive(false);
    }

}
