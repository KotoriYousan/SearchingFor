using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;



namespace Yarn.Unity
{

    public struct MyLine
    {
        public string speaker;
        public string text;
        public string rawText;
    };

    public class SearchingforDialogueUI : Yarn.Unity.DialogueUIBehaviour
    {

        private bool userRequestedNextLine = false;

        public GameObject dialogueContainer;
        public List<Button> optionButtons;

        [Tooltip("How quickly to show the text, in seconds per character")]
        public float textSpeed = 0.025f;

        public UnityEngine.Events.UnityEvent onLineStart;
        public UnityEngine.Events.UnityEvent onLineFinishDisplaying;
        public DialogueRunner.StringUnityEvent onLineUpdate;
        public UnityEngine.Events.UnityEvent onLineEnd;
        public DialogueRunner.StringUnityEvent onCommand;

        public UnityEngine.Events.UnityEvent onOptionsStart;
        public UnityEngine.Events.UnityEvent onOptionsEnd;
        private bool waitingForOptionSelection = false;
        private System.Action<int> currentOptionSelectionHandler;


        private MyLine currentLine;


        /// Runs a line.
        /// <inheritdoc/>
        public override Dialogue.HandlerExecutionType RunLine(Yarn.Line line, ILineLocalisationProvider localisationProvider, System.Action onLineComplete)
        {
            // Start displaying the line; it will call onComplete later
            // which will tell the dialogue to continue

            //MyLine myLine = new MyLine();
            MyLine myLine = new MyLine();


            // The raw text we'll be showing for this line.
            string raw = localisationProvider.GetLocalisedTextForLine(line);
            if (raw == null)
            {
                Debug.LogWarning($"Line {line.ID} doesn't have any localised text.");
                raw = line.ID;
            }

            myLine.rawText = raw;
            myLine.text = raw.Substring(raw.IndexOf(':') + 2);
            myLine.speaker = raw.Substring(0, raw.IndexOf(':'));

            StartCoroutine(DoRunLine(myLine, localisationProvider, onLineComplete));
            return Dialogue.HandlerExecutionType.PauseExecution;
        }

        /// Show a line of dialogue, gradually        
        private IEnumerator DoRunLine(MyLine line, ILineLocalisationProvider localisationProvider, System.Action onComplete)
        {
            


           

            userRequestedNextLine = false;

            currentLine = line;


            //say the line
            onLineStart?.Invoke();


            string text = line.text;
            string speakerName = line.speaker;

            if (textSpeed > 0.0f)
            {
                // Display the line one character at a time
                var stringBuilder = new StringBuilder();

                foreach (char c in text)
                {
                    stringBuilder.Append(c);
                    onLineUpdate?.Invoke(stringBuilder.ToString());
                    if (userRequestedNextLine)
                    {
                        // We've requested a skip of the entire line.
                        // Display all of the text immediately.
                        onLineUpdate?.Invoke(text);
                        break;
                    }
                    yield return new WaitForSeconds(textSpeed);
                }
            }
            else
            {
                // Display the entire line immediately if textSpeed <= 0
                onLineUpdate?.Invoke(text);
            }

            // We're now waiting for the player to move on to the next line
            userRequestedNextLine = false;

            // Indicate to the rest of the game that the line has finished being delivered
            onLineFinishDisplaying?.Invoke();

            while (userRequestedNextLine == false)
            {
                yield return null;
            }

            // Avoid skipping lines if textSpeed == 0
            yield return new WaitForEndOfFrame();

            // Hide the text and prompt
            onLineEnd?.Invoke();

            onComplete();

        }

        public MyLine GetLineInfo()
        {
            return currentLine;
        }


        /// Runs a set of options.
        /// <inheritdoc/>
        public override void RunOptions(Yarn.OptionSet optionSet, ILineLocalisationProvider localisationProvider, System.Action<int> onOptionSelected)
        {
            StartCoroutine(DoRunOptions(optionSet, localisationProvider, onOptionSelected));
        }

        private IEnumerator DoRunOptions(Yarn.OptionSet optionsCollection, ILineLocalisationProvider localisationProvider, System.Action<int> selectOption)
        {
            // Do a little bit of safety checking
            if (optionsCollection.Options.Length > optionButtons.Count)
            {
                Debug.LogWarning("There are more options to present than there are" +
                                 "buttons to present them in. This will cause problems.");
            }

            // Display each option in a button, and make it visible
            int i = 0;

            waitingForOptionSelection = true;

            currentOptionSelectionHandler = selectOption;

            foreach (var optionString in optionsCollection.Options)
            {
                optionButtons[i].gameObject.SetActive(true);

                // When the button is selected, tell the dialogue about it
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => SelectOption(optionString.ID));

                var optionText = localisationProvider.GetLocalisedTextForLine(optionString.Line);

                if (optionText == null)
                {
                    Debug.LogWarning($"Option {optionString.Line.ID} doesn't have any localised text");
                    optionText = optionString.Line.ID;
                }

                var unityText = optionButtons[i].GetComponentInChildren<Text>();
                if (unityText != null)
                {
                    unityText.text = optionText;
                }

                var textMeshProText = optionButtons[i].GetComponentInChildren<TMPro.TMP_Text>();
                if (textMeshProText != null)
                {
                    textMeshProText.text = optionText;
                }

                i++;
            }

            onOptionsStart?.Invoke();

            // Wait until the chooser has been used and then removed 
            while (waitingForOptionSelection)
            {
                yield return null;
            }


            // Hide all the buttons
            foreach (var button in optionButtons)
            {
                button.gameObject.SetActive(false);
            }

            onOptionsEnd?.Invoke();

        }


        /// Runs a command.
        /// <inheritdoc/>
        public override Dialogue.HandlerExecutionType RunCommand(Yarn.Command command, System.Action onCommandComplete)
        {
            // Dispatch this command via the 'On Command' handler.
            onCommand?.Invoke(command.Text);

            // Signal to the DialogueRunner that it should continue
            // executing. (This implementation of RunCommand always signals
            // that execution should continue, and never calls
            // onCommandComplete.)
            return Dialogue.HandlerExecutionType.ContinueExecution;
        }
        

        public void MarkLineComplete()
        {
            userRequestedNextLine = true;
        }

        public void SelectOption(int optionID)
        {
            if (waitingForOptionSelection == false)
            {
                Debug.LogWarning("An option was selected, but the dialogue UI was not expecting it.");
                return;
            }
            waitingForOptionSelection = false;
            currentOptionSelectionHandler?.Invoke(optionID);
        }
        

    }

}
