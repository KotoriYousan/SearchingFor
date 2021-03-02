using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesktopLoader : MonoBehaviour
{

    public GameObject SubmitNovelPage;
    public InputField inputField;
    public InputField novelTitleInputField;

    public GameObject NovelSite;
    public Text NovelText;
    public Text NovelTitleText;


    void Awake()
    {
        novelTitleInputField.text = "chapter title";
        inputField.text = GameManager.instance.GetCurrentText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSubmitNovelButtonClicked()
    {
        GameManager.instance.SetCurrentText(inputField.text);
        NovelText.text = GameManager.instance.GetCurrentText();

        //temp code
        NovelTitleText.text = novelTitleInputField.text;

        SubmitNovelPage.SetActive(false);
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
