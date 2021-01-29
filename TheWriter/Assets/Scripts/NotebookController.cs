using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotebookController : MonoBehaviour
{

    public Text Notebook;

    // Start is called before the first frame update
    void Start()
    {
        Notebook.text = "顾谷谷向前走去，对她来说这只是一小步而已。如此微小的一步对于调查恐怕也不会有多大作用。\n也许这种调查到头来都是徒劳，更何况不论如何认真做事，也总有可能大获全败。";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "item")
        {
            Debug.Log("item triggered");
            Notebook.text = Notebook.text + "\nThere's a " + other.gameObject.name + " on the victim's forehead.";
            Notebook.text = Notebook.text + "\n领带为什么会绑在额头上？可能会是凶器吗？";
        }
    }
}
