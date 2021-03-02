using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ShowIconTrigger : MonoBehaviour
{

    public GameObject IconCanvas;
    public string itemName = "";

    public string talkToNode = "";

    private DialogueRunner dialogueRunner;
    public bool triggered;

    [Header("Optional")]
    public YarnProgram scriptToLoad;

    private void Awake()
    {
        gameObject.AddComponent<Outline>();
        gameObject.GetComponent<Outline>().enabled = false;
    }

    void Start()
    {
        IconCanvas = transform.GetChild(0).gameObject;
        if (scriptToLoad != null)
        {
            dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
            dialogueRunner.Add(scriptToLoad);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("item triggered");
            IconCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("item exit triggered");
            IconCanvas.SetActive(false);
        }
    }

    public void InvestigateItem()
    {
        if (triggered == false)
        {
            triggered = true;
            //DialogueRunner dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
            dialogueRunner.StartDialogue(talkToNode);
        }
    }

    private void OnMouseOver()
    {
        Debug.Log("mouse over obj");
        gameObject.GetComponent<Outline>().enabled = true;
    }

    private void OnMouseExit()
    {
        Debug.Log("mouse no longer over obj");
        gameObject.GetComponent<Outline>().enabled = false;
    }

}
