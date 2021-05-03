using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yarn.Unity;

public class SceneLoader : MonoBehaviour
{

    public Text dreamnoveltext;
    public Text realnoveltext;

    
    public GameObject dreamNovelTexts;
    public GameObject realNovelTexts;


    public GameObject oneirosScene;
    public GameObject desktopScene;
    public GameObject submitText;

    public GameObject NovelSitePage;
    public Text ChapterTitleText;
    public List<List<string>> chapterContent = new List<List<string>>();
    private int curPos;
    public Button NextCptButton,PrevCptButton;

    public GameObject timeManager;


    public GameObject bedroomScene;


    [YarnCommand("Load")]
    public void LoadSceneOnName(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }


    public void LoadDesktop()
    {
        curPos = GameManager.instance.GetChapterCount();
        ChapterTitleText.text = "Chapter "+curPos;
        CheckChapterTurnerButtons();
        NovelSitePage.SetActive(true);


        //clear previous chapter
        int childn = realNovelTexts.transform.childCount;
        for (int i = childn - 1; i > 0; i--)
        {
            Destroy(realNovelTexts.transform.GetChild(i).gameObject);
        }

        //load new chapter
        int childnums = dreamNovelTexts.transform.childCount;
        List<string> curChapter = new List<string>();

        for(int i = 1; i< childnums; i++)
        {
            GameObject go = Instantiate(submitText);
            go.GetComponent<Text>().text = dreamNovelTexts.transform.GetChild(i).GetComponent<Text>().text;
            go.transform.SetParent(realNovelTexts.transform);
            go.transform.localScale = new Vector3(1, 1, 1);

            curChapter.Add(go.GetComponent<Text>().text);

        }

        chapterContent.Add(curChapter);
        
        for(int i=childnums-1; i > 0; i--)
        {
            Destroy(dreamNovelTexts.transform.GetChild(i).gameObject);
        }

        oneirosScene.SetActive(false);
        desktopScene.SetActive(true);
    }

    [YarnCommand("LoadOneiros")]
    public void LoadOneiros()
    {
        GameManager.instance.ChapterCountPlus1();
        //do sth
        bedroomScene.SetActive(false);
        oneirosScene.SetActive(true);
        desktopScene.SetActive(false);
        

        timeManager.GetComponent<TimeManager>().ResetTimer();
    }

    public void LoadBedroom()
    {
        bedroomScene.SetActive(true);
        LoadFlashback();
    }

    public void NextChapter()
    {
        curPos++;
        ChapterTitleText.text = "Chapter " + curPos;
        CheckChapterTurnerButtons();

        int childnums = realNovelTexts.transform.childCount;
        for(int i = childnums - 1; i > 0; i--)
        {
            Destroy(realNovelTexts.transform.GetChild(i).gameObject);
        }

        List<string> curCpt = chapterContent[curPos-1];
        for(int i = 0; i < curCpt.Count;i++)
        {
            GameObject go = Instantiate(submitText);
            go.GetComponent<Text>().text = curCpt[i];
            go.transform.SetParent(realNovelTexts.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
        }

    }
    
    public void PrevChapter()
    {
        curPos--;
        ChapterTitleText.text = "Chapter " + curPos;
        CheckChapterTurnerButtons();

        int childnums = realNovelTexts.transform.childCount;
        for (int i = childnums - 1; i > 0; i--)
        {
            Destroy(realNovelTexts.transform.GetChild(i).gameObject);
        }

        List<string> curCpt = chapterContent[curPos - 1];
        for (int i = 0; i < curCpt.Count; i++)
        {
            GameObject go = Instantiate(submitText);
            go.GetComponent<Text>().text = curCpt[i];
            go.transform.SetParent(realNovelTexts.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    private void CheckChapterTurnerButtons()
    {
        if(curPos == GameManager.instance.GetChapterCount())
        {
            NextCptButton.gameObject.SetActive(false);
        }
        else
        {
            NextCptButton.gameObject.SetActive(true);
        }

        if(curPos == 1)
        {
            PrevCptButton.gameObject.SetActive(false);
        }
        else
        {
            PrevCptButton.gameObject.SetActive(true);
        }

    }


    private void LoadFlashback()
    {
        DialogueRunner runner = FindObjectOfType<DialogueRunner>();
        int cpt = GameManager.instance.GetChapterCount();
        switch (cpt)
        {
            case 1:
                runner.StartDialogue("flashback1");
                break;
        }
    }

}
