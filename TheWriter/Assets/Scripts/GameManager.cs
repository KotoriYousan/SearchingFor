using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;


    public static string currentNovelText;

    public List<string> currentNovelTexts;

    public GameObject novelTexts;

    public int chapterCount = 1;

 
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void OnApplicationQuit()
    {
        GameManager.instance = null;
    }


    public void ChapterCountPlus1() {
        chapterCount++;
    }

    public int GetChapterCount()
    {
        return chapterCount;
    }
    
    public void SetCurrentText(string text)
    {
        currentNovelText = text;
    }

    public string GetCurrentText()
    {
        return currentNovelText;
    }

    public void SetCurrentTexts(GameObject texts)
    {
        novelTexts = texts;
    }

    public GameObject GetCurrentTexts()
    {
        return novelTexts;
    }

}
