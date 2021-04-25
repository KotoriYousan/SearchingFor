using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCamera : MonoBehaviour
{
    //从玩家角度raycast
    public Curve curve;
    //public Camera cam;
    public Transform player;
    public LayerMask blockLayer;
    public SkinnedMeshRenderer[] playerMesh;
    public float hiddenDistance;

    private Vector3 originPos;
    private Vector3 currentPositionVelocity;
    private Vector3 camDir;
    private float curvePlayerDistance;


    private void FixedUpdate()
    {
        originPos = curve.GetPositionAt();
        camDir = (originPos - player.position).normalized;
        curvePlayerDistance = curve.distance;
        RaycastHit hit;

        if (Physics.Raycast(player.position, camDir, out hit, curvePlayerDistance, blockLayer))
        {
             float distance = Vector3.Distance(transform.position, hit.point);
             Vector3 targetPosition = originPos - (curvePlayerDistance - hit.distance) * camDir;
             transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentPositionVelocity, curve.smoothTime);
             //transform.position = targetPosition;
            if (hit.distance < hiddenDistance)
            {
                foreach (SkinnedMeshRenderer smr in playerMesh){
                    smr.enabled = false;
                }
                //playerMesh.enabled = false;
            }
        }
        else
        {

            transform.position = Vector3.SmoothDamp(transform.position, originPos, ref currentPositionVelocity, curve.smoothTime);
            //transform.position = originPos;

            foreach (SkinnedMeshRenderer smr in playerMesh)
            {
                smr.enabled = true;
            }

            //playerMesh.enabled = true;
        }
        transform.LookAt(player.position);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Debug.DrawLine(player.position, player.position + camDir * curvePlayerDistance);
     
    }
}
