using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollider : MonoBehaviour
{
    [Header("1 = APP, 2 = Teaching Building, 3 = Dorm, 4 = Office")]
    [Range(1,4)]
    public int Building;
    public GameObject[] LevelObject;
    public GameObject[] SpecialObject;
    public int Level;

    private bool matchLevel = false;

    private void Start()
    {
        if (LevelObject != null)
        {
            foreach (var obj in LevelObject)
            {
                obj.SetActive(false);
            }
        }
        if (SpecialObject != null)
        {
            foreach (var obj in SpecialObject)
            {
                obj.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (LevelObject != null)
            {
                foreach (var obj in LevelObject)
                {
                    obj.SetActive(true);
                }
            }
            //Debug.Log("Enter");
            if (matchLevel)
            {
                foreach (var obj in SpecialObject)
                {
                    obj.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (LevelObject != null)
            {
                foreach (var obj in LevelObject)
                {
                    obj.SetActive(false);
                }
            }

            if (matchLevel)
            {
                foreach (var obj in SpecialObject)
                {
                    obj.SetActive(false);
                }

            }
            
        }
    }
    private void Update()
    {
        int APPLevel = PlayerPrefs.GetInt("APPLevel");
        int OfficeLevel = PlayerPrefs.GetInt("OfficeLevel");
        int DormLevel = PlayerPrefs.GetInt("DormLevel");

        switch (Building)
        {
            case 1:
                {
                    if (Level == APPLevel)
                        matchLevel = true;
                    else
                        matchLevel = false;
                }
                break;
            case 2:
                {}
                break;
            case 3:
                {
                    if (Level == DormLevel)
                        matchLevel = true;
                    else
                        matchLevel = false;
                }
                break;
            case 4:
                {
                    if (Level == OfficeLevel)
                        matchLevel = true;
                    else
                        matchLevel = false;
                }
                break;
            default:
                Debug.Log("Wrong Building Number");
                break;
        }
        
    }
}
