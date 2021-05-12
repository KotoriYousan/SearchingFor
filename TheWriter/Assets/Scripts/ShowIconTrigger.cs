using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ShowIconTrigger : MonoBehaviour
{

    //public GameObject IconCanvas;
    public string itemName = "";

    public string talkToNode = "";

    private DialogueRunner dialogueRunner;
    public bool triggered;


    public Texture2D hovercursor;

    //[Header("Optional")]
    //public YarnProgram scriptToLoad;

    private void Awake()
    {
        gameObject.AddComponent<Outline>();
        gameObject.GetComponent<Outline>().enabled = false;
    }

    void Start()
    {/*
        //IconCanvas = transform.GetChild(0).gameObject;
        if (scriptToLoad != null)
        {
            dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
            dialogueRunner.Add(scriptToLoad);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void InvestigateItem()
    {
        if (triggered == false)
        {
            triggered = true;
            //DialogueRunner dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
            dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
            dialogueRunner.StartDialogue(talkToNode);
        }
    }

    private void OnMouseOver()
    {

        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
        {
            return;
        }

        //Debug.Log("mouse over obj" + gameObject.name);
        gameObject.GetComponent<Outline>().enabled = true;

        if (triggered == false)
        {
            Cursor.SetCursor(hovercursor, new Vector2(hovercursor.width / 2, hovercursor.height / 2), CursorMode.Auto);
        }

        if (Input.GetMouseButtonDown(0))
        {
            InvestigateItem();
        }

    }

    private void OnMouseExit()
    {
        //Debug.Log("mouse no longer over obj");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        gameObject.GetComponent<Outline>().enabled = false;
    }

}
