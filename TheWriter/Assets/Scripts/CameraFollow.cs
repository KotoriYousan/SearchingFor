using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /// Target of the camera
    public Transform target;

    /// Minimum position of camera
    public float minPositionX = -5.3f;

    /// Maximum position of camera
    public float maxPositionX = 5.3f;

    /// Minimum position of camera
    public float minPositionZ = -5.3f;

    /// Maximum position of camera
    public float maxPositionZ = 5.3f;

    /// Movement speed of camera
    public float moveSpeed = 1.0f;

    //Camera distance to target
    public float distance = 4.0f;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        var newPosition = Vector3.Lerp(transform.position, target.position + new Vector3(0, 0, distance), moveSpeed * Time.deltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, minPositionX, maxPositionX);
        newPosition.y = transform.position.y;
        newPosition.z = Mathf.Clamp(newPosition.z, minPositionZ, maxPositionZ);

        transform.position = newPosition;
    }

}
