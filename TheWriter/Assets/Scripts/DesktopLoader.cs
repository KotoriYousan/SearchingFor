using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesktopLoader : MonoBehaviour
{

    public InputField inputField;

    void Awake()
    {
        inputField.text = GameManager.instance.GetCurrentText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
