using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    [Header("OFFICE")]
    public float OfficeHeight = 3.3f;
    private Vector3[] OfficeXY = { new Vector3(8.045f, 0f, 2.9f), new Vector3(11.99f, 0f, 2.9f), new Vector3(15.935f, 0f, 2.9f), new Vector3(19.88f, 0f, 2.9f) };
    public GameObject Office;
    [Range(1, 7)]
    public int OfficeLevel = 1;
    [Range(1, 4)]
    public int OfficeRoom = 1;

    [Header("APP")]
    public float APPHeight = 3.3f;
    private Vector3 AppOriPos = new Vector3(0f, 3.3f, 0f);
    public GameObject APP;
    [Range(2, 20)]
    public int AppLevel = 2;

    [Header("Dorm")]
    public float DormHeight = 4.1f;
    private Vector3[] DormXY = { new Vector3(27.3817f, 0f, 3.700001f), new Vector3(22.727f, 0f, 3.700001f), new Vector3(18.072f, 0f, 3.700001f), new Vector3(9.31f, 0f, 3.700001f), new Vector3(4.655f, 0f, 3.700001f), new Vector3(-4.4703e-07f, 0f, 3.700001f) };
    public GameObject Dorm;
    [Range(1,6)]
    public int DormLevel = 1;
    [Range(1,6)]
    public int DormRoom = 1;


    public void ChangePosition()
    {
        Office.transform.localPosition = OfficeXY[OfficeRoom - 1] + (OfficeHeight * Vector3.up) * (OfficeLevel - 1);
        APP.transform.localPosition = AppOriPos + (AppLevel - 2) * (APPHeight * Vector3.up);
        Dorm.transform.localPosition = DormXY[DormRoom - 1] + (DormHeight * Vector3.up) * (DormLevel - 1);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangePosition();
            PlayerPrefs.SetFloat("OfficeX", Office.transform.localPosition.x);
            PlayerPrefs.SetFloat("OfficeY", Office.transform.localPosition.y);
            PlayerPrefs.SetFloat("OfficeZ", Office.transform.localPosition.z);
            PlayerPrefs.SetInt("OfficeLevel", OfficeLevel);

            PlayerPrefs.SetFloat("APPX", APP.transform.localPosition.x);
            PlayerPrefs.SetFloat("APPY", APP.transform.localPosition.y);
            PlayerPrefs.SetFloat("APPZ", APP.transform.localPosition.z);
            PlayerPrefs.SetInt("APPLevel", AppLevel);

            PlayerPrefs.SetFloat("DormX", Dorm.transform.localPosition.x);
            PlayerPrefs.SetFloat("DormY", Dorm.transform.localPosition.y);
            PlayerPrefs.SetFloat("DormZ", Dorm.transform.localPosition.z);
            PlayerPrefs.SetInt("DormLevel", DormLevel);
        }
    }
}
