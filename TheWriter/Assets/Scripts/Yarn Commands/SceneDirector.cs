using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class SceneDirector : MonoBehaviour
{

    [YarnCommand("switch_ordinary")]
    public void Switch_ordinary()
    {
        Debug.Log("s ordinary");
        SceneManager.LoadScene("O_Apartment");
    }

    [YarnCommand("switch_grass")]
    public void Switch_grass()
    {
        Debug.Log("s grass");
        SceneManager.LoadScene("G_Apartment");
    }

    [YarnCommand("switch_sensory")]
    public void Switch_sensory()
    {
        Debug.Log("s sensory");
        SceneManager.LoadScene("S_Apartment");
    }

    [YarnCommand("switch_home")]
    public void Switch_home()
    {
        Debug.Log("s home");
        SceneManager.LoadScene("Home");
    }

    public void EndInvestigationOOffice()
    {
        SceneManager.LoadScene("O_Office");
    }

}
