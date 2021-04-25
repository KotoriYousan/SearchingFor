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
        SceneManager.LoadScene("2d-room-scene", LoadSceneMode.Additive);
        Debug.Log(GameManager.instance.GetCurrentText());
        //realnoveltext.text = GameManager.instance.GetCurrentText();
    }

    public void LoadDreamScene()
    {
        //SceneManager.LoadScene("3d-sample-scene");
        gameObject.SetActive(false);
    }

    [YarnCommand("Load")]
    public void LoadSceneOnName(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }


}
