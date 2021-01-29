using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Item : MonoBehaviour
{
    
    public string itemName = "";

    public string talkToNode = "";

    private DialogueRunner dialogueRunner;
    public bool triggered;

    [Header("Optional")]
    public YarnProgram scriptToLoad;

    void Start()
    {
        if (scriptToLoad != null)
        {
            dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
            dialogueRunner.Add(scriptToLoad);
        }
    }

    /*
    private void OnTrigger2D(Collider2D collision)
    {

        if (Input.GetKeyDown(KeyCode.Space) & (triggered == false))
        {
            
            triggered = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //DialogueRunner dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
            dialogueRunner.StartDialogue(talkToNode);
        }
        
    }*/

    public void InvestigateItem()
    {
        if(triggered == false)
        {
            triggered = true;
            //DialogueRunner dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
            dialogueRunner.StartDialogue(talkToNode);
        }
    }

}
