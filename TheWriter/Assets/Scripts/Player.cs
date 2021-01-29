using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Player : MonoBehaviour
{
    public float minPosition = -5.3f;
    public float maxPosition = 5.3f;

    public float moveSpeed = 1.0f;

    public float interactionRadius = 2.0f;

    public float movementFromButtons { get; set; }

    /// Draw the range at which we'll start talking to people.
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        // Flatten the sphere into a disk, which looks nicer in 2D games
        Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1, 1, 0));

        // Need to draw at position zero because we set position in the line above
        Gizmos.DrawWireSphere(Vector3.zero, interactionRadius);
    }

    /// Update is called once per frame
    void Update()
    {

        // Remove all player control when we're in dialogue
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
        {
            return;
        }

        // Move the player, clamping them to within the boundaries 
        // of the level.
        var movement = Input.GetAxis("Horizontal");
        movement += movementFromButtons;
        movement *= (moveSpeed * Time.deltaTime);

        var newPosition = transform.position;
        newPosition.x += movement;
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition, maxPosition);

        transform.position = newPosition;

        // Detect if we want to start a conversation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckForNearbyItems();
        }
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
            Debug.Log(target.itemName);
            FindObjectOfType<DialogueRunner>().StartDialogue(target.talkToNode);
        }
    }

}

