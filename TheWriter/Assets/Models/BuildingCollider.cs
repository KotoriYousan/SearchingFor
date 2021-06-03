using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollider : MonoBehaviour
{
    private Curve curve;
    private CameraNew camNew;
    public bool inside;
    private void Start()
    {
        //curve = FindObjectOfType<Curve>().GetComponent<Curve>();
        camNew = FindObjectOfType<CameraNew>().GetComponent<CameraNew>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inside = true;
            //curve.SetInBuilding(true);
            camNew.SetinBuilding(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inside = false;
            curve.SetInBuilding(false);
            camNew.SetinBuilding(false);
        }
    }

}
