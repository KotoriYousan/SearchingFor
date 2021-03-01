using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;


    public static string currentNovelText;
    /*
    public static GameManager Instance
    {
        get
        {
            if (GameManager.instance == null)
            {
                DontDestroyOnLoad(GameManager.instance);
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
        }

    }
    */
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
    
    public void SetCurrentText(string text)
    {
        currentNovelText = text;
    }

    public string GetCurrentText()
    {
        return currentNovelText;
    }

}
