using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SphereCast : MonoBehaviour
{
    public GameObject player;
    //public GameObject TPCamera;
    public Curve curve;
    public GameObject currentHitObject;
    public float sphereRadius;
    public float overlapSphereRadius;
    public float maxDistance;
    public LayerMask layerMask;
    public bool treeInbetween = false;

    public float currentHitDistance;
    private Vector3 origin;
    private Vector3 direction;
    private Vector3 camDirection;

    public Collider[] hitColliders;
    
    [Serializable]
    public class OverlapTree
    {
        public GameObject treeObject;
        public float hitDistance;
        public Collider treeCollider;
    }

    [SerializeField] private List<OverlapTree> treeList = new List<OverlapTree>();
    void Update()
    {
        origin = player.transform.position;
        direction = player.transform.forward;
        //get all the colliders inside the sphere 
        hitColliders = Physics.OverlapSphere(origin, overlapSphereRadius, layerMask);
        foreach (var hitCollider in hitColliders)
        {
            direction = hitCollider.transform.position - player.transform.position;
            //cast a ray from the player to each and every object
            CastToTree();
            //if the object is not in the list, add it to the list, else, update the distance
            if ((!treeList.Any(f => f.treeObject == hitCollider.gameObject)))
            {
                treeList.Add(new OverlapTree
                {
                    treeObject = hitCollider.gameObject,
                    hitDistance = currentHitDistance,
                    treeCollider = hitCollider,
                });
            }
            else
            {
                OverlapTree result = treeList.Find(f => f.treeObject == hitCollider.gameObject);
                result.hitDistance = currentHitDistance;
            }
        }
        //if the any object in the list is now outside the sphere, delete it 
        for (int i = 0; i < treeList.Count; i++)
        {
            if ((Array.Exists(hitColliders, j => j.gameObject == treeList[i].treeObject)) == false)
            {
                treeList.Remove(treeList[i]);
            }
        }
        //sort the list by distance
        treeList = treeList.OrderBy(w => w.hitDistance).ToList();
        //CheckCamera();
        //ChangePosition();
        //---------------------------------------
        //check if there is anything between the player and the camera
        RaycastHit cameraHit;
        camDirection = Vector3.Normalize(curve.GetPositionAt() - player.transform.position);
        if (Physics.Raycast(player.transform.position,camDirection,out cameraHit, maxDistance,layerMask))
        {
            /*if (cameraHit.transform.gameObject == treeList[0].treeObject)
            {
                treeInbetween = true;
                Debug.Log("tree");
            }
            else treeInbetween = false;*/
            treeInbetween = true;
        }
        else treeInbetween = false;
    }

    public void CastToTree()
    {
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
        }
        else
        {
            currentHitDistance = maxDistance;
            currentHitObject = null;
        }
    }
    //public bool CheckCamera()
    //{
    //    if (treeList[0].treeCollider.bounds.Contains(TPCamera.transform.position))
    //    { return true; }
    //    else return false;
    //}
    //public void ChangePosition()
    //{
    //    Vector3 treeDirection = Vector3.Normalize(treeList[0].treeObject.transform.position - player.transform.position);
        
    //    if (treeDirection == camDirection)
    //    {
    //        TPCamera.transform.position -= treeDirection * (treeList[0].hitDistance - 0.05f);
    //    }

    //}
    public bool GetInbetween()
    {
        return treeInbetween;
    }
    public float GetDistance()
    {
        return treeList[0].hitDistance;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin, overlapSphereRadius);
        Debug.DrawLine(player.transform.position, player.transform.position + camDirection * maxDistance);
    }
}
