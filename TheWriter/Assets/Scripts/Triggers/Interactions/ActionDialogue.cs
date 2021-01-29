using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ActionDialogue : SceneAction
{
    private DialogueRunner dialogueRunner;
    private float interactionRadius = 3f;

    private void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    public override void Interact()
    {
        //trigger dialogue
        CheckForNearbyItems();
    }

    public void CheckForNearbyItems()
    {
        
        var allParticipants = new List<Item>(FindObjectsOfType<Item>());
        var target = allParticipants.Find(delegate (Item item) {
            return string.IsNullOrEmpty(item.talkToNode) == false && // has a conversation node?
            (item.transform.position - this.transform.position)// is in range?
            .magnitude <= interactionRadius;
        });
        if (target != null)
        {
            // Kick off the dialogue at this node.
            Debug.Log(target.talkToNode);
            dialogueRunner.StartDialogue(target.talkToNode);
        }
    }

}
