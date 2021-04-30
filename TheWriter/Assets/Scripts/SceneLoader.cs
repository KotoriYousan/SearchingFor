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

    public GameObject timeManager;


    [YarnCommand("Load")]
    public void LoadSceneOnName(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }


    public void LoadDesktop()
    {

        int childnums = dreamNovelTexts.transform.childCount;

        for(int i = 1; i< childnums; i++)
        {
            GameObject go = Instantiate(submitText);
            go.GetComponent<Text>().text = dreamNovelTexts.transform.GetChild(i).GetComponent<Text>().text;
            go.transform.SetParent(realNovelTexts.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
        }
        
        for(int i=childnums-1; i > 0; i--)
        {
            Destroy(dreamNovelTexts.transform.GetChild(i).gameObject);
        }

        oneirosScene.SetActive(false);
        desktopScene.SetActive(true);
    }

    public void LoadOneiros()
    {
        //do sth
        oneirosScene.SetActive(true);
        desktopScene.SetActive(false);

        timeManager.GetComponent<TimeManager>().ResetTimer();
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        //if ((SceneManager.GetSceneByName("2d-room-scene").isLoaded == true)  && (SceneManager.GetSceneByName("2d-room-scene").GetRootGameObjects()[0].activeSelf == true))
        //{
        //    InstantiateRoomScene();
        //}
    }

    public void InstantiateRoomScene()
    {
        Debug.Log("2d scene instantiate");
            //realNovelTexts.transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.currentNovelTexts[0];
            foreach(string txt in GameManager.instance.currentNovelTexts)
            {
                //GameObject txtObj = Instantiate(realNovelprefab);
                GameObject textObj = new GameObject();
                
                textObj.AddComponent<Text>();
                textObj.GetComponent<Text>().text = txt;
                textObj.GetComponent<Text>().font = realNovelTexts.transform.GetChild(0).GetComponent<Text>().font;
                textObj.AddComponent<ContentSizeFitter>();
                textObj.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                //textObj.transform.localScale = new Vector3(1, 1, 1);
                
                textObj.transform.SetParent(realNovelTexts.transform);
                textObj.transform.localScale = new Vector3(1, 1, 1);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadRoomScene()
    {
        //Debug.Log(dreamnoveltext.text);
        GameManager.instance.SetCurrentText(dreamNovelTexts.transform.GetChild(0).GetComponent<Text>().text);
        //GameManager.instance.SetCurrentTexts(dreamNovelTexts);


        foreach(Transform txtTrans in dreamNovelTexts.transform.GetComponentInChildren<Transform>())
        {
            GameManager.instance.currentNovelTexts.Add(txtTrans.GetComponent<Text>().text);
        }


        Debug.Log(GameManager.instance.GetCurrentText());

        if (SceneManager.GetSceneByName("2d-room-scene").isLoaded == true)
        {
            SceneManager.GetSceneByName("2d-room-scene").GetRootGameObjects()[0].gameObject.SetActive(true);
            
        }
        else
        {
            SceneManager.LoadScene("2d-room-scene", LoadSceneMode.Additive);
        }
        SceneManager.GetSceneByName("3d-sample-scene").GetRootGameObjects()[0].gameObject.SetActive(false);

        //Debug.Log(GameManager.instance.GetCurrentTexts().transform.GetChild(0).GetComponent<Text>().text);
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
        InstantiateRoomScene();
        //realnoveltext.text = GameManager.instance.GetCurrentText();
        //realNovelTexts.transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.GetCurrentText();
        
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
    */
    


}
