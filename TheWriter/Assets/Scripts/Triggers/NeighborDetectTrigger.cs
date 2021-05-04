using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborDetectTrigger : MonoBehaviour
{

    public GameObject ZhangzheIdle;

    public GameObject neighborDoorlocked, neighbordoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(GameManager.instance.GetPlayerNeighborLevel() == 1)
            {
                ZhangzheIdle.SetActive(true);
            }
            if (GameManager.instance.GetPlayerNeighborLevel() == 2)
            {
                ZhangzheIdle.SetActive(false);
                neighborDoorlocked.SetActive(false);
                neighbordoor.SetActive(true);
            }
        }
    }

}
