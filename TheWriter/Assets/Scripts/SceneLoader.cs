using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        GameManager.instance.SetCurrentText(dreamnoveltext.text);
        SceneManager.LoadScene("2d-room-scene");
        Debug.Log(GameManager.instance.GetCurrentText());
        //realnoveltext.text = GameManager.instance.GetCurrentText();
    }

    public void LoadDreamScene()
    {
        SceneManager.LoadScene("3d-sample-scene");
    }
}
