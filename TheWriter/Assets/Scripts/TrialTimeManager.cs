using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrialTimeManager : MonoBehaviour
{
    public float timer = 0.0f;
    public int gameHours;
    public int gameMinutes;
    public int startHours = 0;
    public float countdownTime = 120.0f;

    public Text timerText;

    public GameObject SceneLoader;
    public GameObject EndTrialVersion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // seconds in float
        //timer += Time.deltaTime;
        
        countdownTime -= Time.deltaTime;
        Debug.Log(countdownTime);
        // turn seconds in float to int
        gameMinutes = (int)(countdownTime % 60);
        gameHours = (int)(countdownTime / 60);
        //print(gameHours+":"+gameMinutes);
        //print(GetGameTime());
        timerText.text = GetGameTime();
        CheckIfEndtime();
    }

    public int GetGameHours()
    {
        return startHours + gameHours;
    }

    public int GetGameMinutes()
    {
        return gameMinutes;
    }

    public string GetGameTime()
    {
        string gametime;
        gametime = gameHours + ":";

        if (gameMinutes < 10)
        {
            gametime = gametime + "0" + gameMinutes;
        }
        else
        {
            gametime = gametime + gameMinutes;
        }

        return gametime;
    }

    void CheckIfEndtime()
    {
        if (gameHours <= 0 & gameMinutes <= 0)
        {
            Debug.Log("times up");
            EndTrialVersion.SetActive(true);
            //SceneLoader.GetComponent<SceneLoader>().LoadRoomScene();
            //SceneManager.LoadScene("2d-room-scene");
        }
    }

    public void ExitTrial()
    {
        //SceneManager.LoadScene("2d-room-scene");
        //SceneLoader.GetComponent<SceneLoader>().LoadRoomScene();
        SceneManager.LoadScene("EndTrialDream");
    }
}
