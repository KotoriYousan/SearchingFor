using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraNew : MonoBehaviour
{
    public CinemachineFreeLook freeCamera;
    public Camera cam;
    public SkinnedMeshRenderer[] playerMesh;

    float oriMouseY;
    float oriMouseX;

    float camdis;
    public bool inBuilding = false;
    
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        oriMouseY = Input.GetAxis("Mouse Y");
        oriMouseX = Input.GetAxis("Mouse X");
        
        
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            //show cursor
            Cursor.visible = true;
        }
        else
        {          
            freeCamera.m_YAxis.m_InputAxisValue = oriMouseY;
            freeCamera.m_XAxis.m_InputAxisValue = oriMouseX;
            //hide cursor
            Cursor.visible = false;

        }
        camdis = Vector3.Distance(cam.transform.position, freeCamera.m_LookAt.position);
        if (camdis <= 0.5f)
        {
            foreach (SkinnedMeshRenderer smr in playerMesh)
            {
                smr.enabled = false;
               
            }
            //playerMesh.enabled = false;
        }
        else 
        {
            foreach (SkinnedMeshRenderer smr in playerMesh)
            {
                smr.enabled = true;
            }
        }

        if (inBuilding)
        {
            freeCamera.m_Orbits[0] = new CinemachineFreeLook.Orbit(4f, 0.5f);
            freeCamera.m_Orbits[1] = new CinemachineFreeLook.Orbit(2f, 1f);
            freeCamera.m_Orbits[2] = new CinemachineFreeLook.Orbit(0f, 0.5f);
        }
        else
        {
            freeCamera.m_Orbits[0] = new CinemachineFreeLook.Orbit(4f, 1f);
            freeCamera.m_Orbits[1] = new CinemachineFreeLook.Orbit(2f, 2.75f);
            freeCamera.m_Orbits[2] = new CinemachineFreeLook.Orbit(0f, 1f);
        }
    }
    public void SetinBuilding(bool i)
    {
        inBuilding = i;
    }
}
