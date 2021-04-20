using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class Curve : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    public Transform handleA;
    public Transform handleB;
    public Transform handleC;
    public Transform handleD;
    public Vector3[] Nodes = new Vector3[10];

    public Transform player;

    public float distance = 2.0f;
    public float currentX = 0.0f;
    public float currentY = 0.0f;

    public float maxAngle = 70.0f;
    public float minAngle = -70.0f;

    public float smoothTime = 0.3f;
    public float rotateSpeedX = 10f;
    public float rotateSpeedY = 10f;
    private Vector3 currentPositionVelocity;

    private void Start()
    {
        Nodes[0] = A.position;
        Nodes[3] = B.position;
        Nodes[6] = C.position;
        Nodes[1] = handleA.position;
        Nodes[2] = handleB.position;
        Nodes[4] = handleC.position;
        Nodes[5] = handleD.position;
        //transform.position = player.position;     
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * rotateSpeedX;
            currentY += Input.GetAxis("Mouse Y") * rotateSpeedY;
            currentY = Mathf.Clamp(currentY, minAngle, maxAngle);
            //currentX = Mathf.Clamp(currentX, minAngle, maxAngle);
        }

        Nodes[0] = A.position;
        Nodes[3] = B.position;
        Nodes[6] = C.position;
        Nodes[1] = handleA.position;
        Nodes[2] = handleB.position;
        Nodes[4] = handleC.position;
        Nodes[5] = handleD.position;


        Vector3 dir = Vector3.forward * (-distance);
        Quaternion rotation = Quaternion.Euler(0, currentX, 0);
        //transform.position = player.position + rotation * dir;
        transform.position = Vector3.SmoothDamp(transform.position, player.position + rotation * dir, ref currentPositionVelocity, smoothTime);
        transform.LookAt(player.position);
    }


    public Vector3 CurveLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 abc = QuadraticLerp(a, b, c, t);
        Vector3 bcd = QuadraticLerp(b, c, d, t);

        return Vector3.Lerp(abc, bcd, t);
    }

    private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(ab, bc, t);
    }

    public Vector3 GetPositionAt()
    {
        float tNode;
       
        if (currentY < 0)
        {
            Vector3 tempC = CreateTempC();
            tNode = (currentY / minAngle);
            return CurveLerp(Nodes[3], tempC, Nodes[5], Nodes[6], tNode);
        }
        else
        {
            tNode = currentY / maxAngle;
            return CurveLerp(Nodes[3], Nodes[2], Nodes[1], Nodes[0], tNode);
        }
    }

    public Vector3 CreateTempC()
    {
        Vector3 tempC;
        Vector3 tempCDir;
        tempCDir = Nodes[3] - Nodes[2];
        tempCDir.Normalize();
        tempC = Nodes[3] + tempCDir * (Nodes[4] - Nodes[3]).magnitude;
        return tempC;
    }
    public Vector3 GetNodes(int i)
    {
        return Nodes[i];
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Curve))]
public class BezierExampleEditor : Editor
{
    public void OnSceneGUI()
    {
        Curve curve = target as Curve;
        Vector3[] Nodes = new Vector3[10];
        Vector3 tempC = curve.CreateTempC();
        for (int i = 0; i < 10; i++)
        {
            Nodes[i] = curve.GetNodes(i);
        }
        Handles.DrawBezier(Nodes[0], Nodes[3], Nodes[1], Nodes[2], Color.yellow, null, 5f);
        Handles.DrawBezier(Nodes[3], Nodes[6], tempC, Nodes[5], Color.yellow, null, 5f);
    }
}
#endif