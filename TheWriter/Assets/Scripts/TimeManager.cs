using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timer = 0.0f;
    public int gameHours;
    public int gameMinutes;
    public int startHours = 9;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // seconds in float
        timer += Time.deltaTime;
        // turn seconds in float to int
        gameMinutes = (int)(timer % 60);
        gameHours = startHours + (int)(timer / 60);
        //print(gameHours+":"+gameMinutes);
        print(GetGameTime());
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
}
