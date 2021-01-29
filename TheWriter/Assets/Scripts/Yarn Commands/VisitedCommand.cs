using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class VisitedCommand : MonoBehaviour
{
    // Drag and drop your Dialogue Runner into this variable.
    public DialogueRunner dialogueRunner;

    public GameObject toShow;

    public void Awake()
    {

        // Create a new command called 'camera_look', which looks at a target.
        dialogueRunner.AddCommandHandler(
            "visited_item",     // the name of the command
            VisitedItem // the method to run
        );
    }

    // The method that gets called when '<<camera_look>>' is run.
    private void VisitedItem(string[] parameters)
    {

        // Take the first parameter, and use it to find the object
        string targetName = parameters[0];
        GameObject target = GameObject.Find(targetName);

        // Log an error if we can't find it
        if (target == null)
        {
            Debug.LogError($"Cannot find {targetName}:" +
                "cannot find target");
            return;
        }

        // Do sth
        target.GetComponent<SpriteRenderer>().enabled = false;
        target.GetComponent<BoxCollider2D>().enabled = false;
        target.GetComponent<Item>().triggered = true;
        //toShow.SetActive(true);
        target.transform.GetChild(0).gameObject.SetActive(true);
    }
}
