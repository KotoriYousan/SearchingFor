using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeywordScript : MonoBehaviour
{

    public int tag;
    public KeywordsManagement keywordsManagement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {/*
        if (Input.GetMouseButtonDown(0))
        {
            

        }*/
    }

    public void OnClickKeywords()
    {
        if(gameObject.GetComponent<Text>().color == Color.white)
        {
            gameObject.GetComponent<Text>().color = Color.red;
            keywordsManagement.countSelect++;
            if (tag == 1)
                keywordsManagement.count1++;
            if (tag == 2)
                keywordsManagement.count2++;
            if (tag == 3)
                keywordsManagement.count3++;
        }
            
    }
    

}
