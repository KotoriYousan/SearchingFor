using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;

public class ConversationHandler : MonoBehaviour
{

    public SearchingforDialogueUI ui;

    public Text notebook;
    //public TMP_Text notebook;
    public TMP_Text speakBubble;
    public GameObject DialogueBubble;
    public Text vnText;

    private string originalText;

    private Camera cam;

    MyLine currentLine;

    private void Awake()
    {
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        ui.onLineStart.AddListener(LineStarted);
        ui.onLineUpdate.AddListener(PrintLine);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ui.MarkLineComplete();
        }
    }

    private void PrintLine(string line)
    {

        //        Debug.Log(line);
        if (currentLine.speaker == "Novel")
        {
            notebook.text = originalText + "\n\n" + line;
        }
        else if (currentLine.speaker == "Narrator")
        {
            vnText.text = line;
        }
        else
        {
            speakBubble.text = line;
        }
    }

    private void LineStarted()
    {
        //play a sound
        //move the cam to a charac
        originalText = notebook.text;

        currentLine = ui.GetLineInfo();
        Debug.Log(currentLine.speaker);

        if(currentLine.speaker == "Novel")
        {
            originalText = notebook.text;
        }
        else if (currentLine.speaker == "Narrator")
        {
            vnText.gameObject.SetActive(true);
        }
        else
        {
            DialogueBubble.SetActive(true);
            
            SetDialoguePosition(GameObject.Find(currentLine.speaker));
        }

    }

    private void LineEnded()
    {
        //give con back to player
        //move cam out

        if(currentLine.speaker == "Novel")
        {
            //do sth
        }
        else if (currentLine.speaker == "Narrator")
        {
            vnText.gameObject.SetActive(false);
        }
        else
        {
            DialogueBubble.SetActive(false);
        }

    }


    private void SetDialoguePosition(GameObject character)
    {
        // Retrieve the position where the top part of the sprite is in the world
        float characterSpriteHeight = character.GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
        


        // Create position with the sprite top location
        Vector3 characterPosition = new Vector3(character.transform.position.x,
                                                characterSpriteHeight + 1f,
                                                character.transform.position.z);

        // Set the DialogueBubble position to the sprite top location in Screen Space
        DialogueBubble.transform.position = cam.WorldToScreenPoint(characterPosition);
    }

}
