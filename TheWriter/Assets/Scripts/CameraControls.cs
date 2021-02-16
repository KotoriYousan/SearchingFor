using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform target;
    public float distance = 3.5f; //Our desired distance
    private float currentDistance; //Our current distance
    [Range(1, 10)] public float xSpeed = 2; 
    [Range(1, 10)] public float ySpeed = 2; 

    public float yMin = -20f;
    public float yMax = 80f;

    public float distanceMin = 1; //Minimum distance from target
    public float distanceMax = 10; //Maximum distance from target

    private Vector3 offset; //Changes our targeted position

    private float x; //Current horizontal rotation
    public float y; //Current vertical rotation

    public LayerMask clipMask; //What layers block the camera

    // Use this for initialization
    void Start()
    {
        currentDistance = distance; //Set our current distance to desired distance
        Vector3 angles = transform.eulerAngles; 
        x = angles.y; //Set x to camera's current horizontal rotation
        y = angles.x; //Set y the camera's current vertical rotation
    }

    void LateUpdate()
    {
        if (target) //Only execute if there is a target
        {
            if (Input.GetMouseButton(1))
            {
                x += Input.GetAxis("Mouse X") * xSpeed; //Set x rotation to mouse input
                y -= Input.GetAxis("Mouse Y") * ySpeed; //Set y rotation to mouse input
                y = Mathf.Clamp(y, yMin, yMax); //Clamp y to desired range


                
            }

            Quaternion rotation = Quaternion.Euler(y, x, 0); //Store rotation for ease of use

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            //This section deals with wall detection
            Vector3 direction = target.position + offset - transform.position;
            RaycastHit hit;
            if (Physics.SphereCast(target.position + offset, 0.25f, -direction / direction.magnitude, out hit, currentDistance + 0.125f, clipMask))
                currentDistance = Mathf.Clamp(hit.distance, 0, distance);
            else if (currentDistance != distance)
                currentDistance = Mathf.Lerp(currentDistance, distance, 10 * Time.deltaTime);
            
            //Set position according to rotation and distance
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -currentDistance) + (target.position + offset);

            //Set our position and rotation to our defined values
            transform.rotation = rotation;
            transform.position = position;

            //target.GetComponent<PlayerControls>().SetRotation(x); //Updates player rotation
        }
    }
    public void SetTarget(Transform t)
    {
        target = t; //Sets target, called by UI in DemoScene
        offset.y = target.GetComponent<CharacterController>().height - 0.25f; //Set camera height according to target height
    }
}