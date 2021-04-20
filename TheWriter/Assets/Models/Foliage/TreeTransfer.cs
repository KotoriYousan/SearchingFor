using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TreeTransfer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float scale = Random.Range(0.9f, 1.4f);
        float rotateY = Random.Range(-180f, 180f);
        //float rotateZ = Random.Range(-180f, 180f);
        gameObject.transform.localScale = Vector3.one * scale;
        gameObject.transform.Rotate(0f, rotateY, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
