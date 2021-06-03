using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public GameObject Player;
    public float moveSpeed;// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var newPosition = Vector3.Lerp(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
