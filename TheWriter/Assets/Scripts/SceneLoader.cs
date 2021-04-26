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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadRoomScene()
    {
        //Debug.Log(dreamnoveltext.text);
        GameManager.instance.SetCurrentText(dreamnoveltext.text);

        if (SceneManager.GetSceneByName("2d-room-scene").isLoaded == true)
        {
            SceneManager.GetSceneByName("2d-room-scene").GetRootGameObjects()[0].gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("2d-room-scene", LoadSceneMode.Additive);
        }

        
        Debug.Log(GameManager.instance.GetCurrentText());
        SceneManager.GetSceneByName("3d-sample-scene").GetRootGameObjects()[0].gameObject.SetActive(false);

        //realnoveltext.text = GameManager.instance.GetCurrentText();
    }

    public void LoadDreamScene()
    {
        //SceneManager.LoadScene("3d-sample-scene");
        //gameObject.SetActive(false);
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("3d-sample-scene"));

        SceneManager.GetSceneByName("3d-sample-scene").GetRootGameObjects()[0].gameObject.SetActive(true);
        SceneManager.GetSceneByName("2d-room-scene").GetRootGameObjects()[0].gameObject.SetActive(false);
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
    }

    [YarnCommand("Load")]
    public void LoadSceneOnName(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }


}
