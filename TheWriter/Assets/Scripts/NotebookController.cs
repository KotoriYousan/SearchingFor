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
        Notebook.text = "开始调查。";
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
            Notebook.text = Notebook.text + "\n捡起了" + other.gameObject.name + "。";
        }
    }
}
