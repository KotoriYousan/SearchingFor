using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class KeywordsManagement : MonoBehaviour
{

    public int count1, count2,count3, countSelect = 0;

    public DialogueRunner dialogueRunner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countSelect == 7)
        {
            for(int i = 0; i < gameObject.transform.childCount; i++)
            {
                if(gameObject.transform.GetChild(i).GetComponent<Text>().color == Color.white)
                {
                    gameObject.transform.GetChild(i).GetComponent<Text>().enabled = false;
                }
            }
            countSelect = 99;
            StartCoroutine(StartEndDialogue());
        }
    }

    private IEnumerator StartEndDialogue()
    {
        dialogueRunner.StartDialogue("end-select");
        yield return null;
    }
}
