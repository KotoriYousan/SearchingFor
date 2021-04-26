using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollider : MonoBehaviour
{
    private Curve curve;
    public bool inside;
    private void Start()
    {
        curve = FindObjectOfType<Curve>().GetComponent<Curve>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inside = true;
            curve.SetInBuilding(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inside = false;
            curve.SetInBuilding(false);
        }
    }

}
