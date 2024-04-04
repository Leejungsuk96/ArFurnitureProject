using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ClassifyPlane : MonoBehaviour
{
    public ARPlane arPlane;

    public MeshRenderer planeMeshRenderer;

    public TextMeshPro text;

    public GameObject textObj;

    GameObject mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = FindAnyObjectByType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateObjectPosition();
        UpdatePlaneColor();
    }

    private void UpdateObjectPosition()
    {
        text.text = arPlane.classification.ToString();
        textObj.transform.position = arPlane.center;
        textObj.transform.LookAt(mainCam.transform);
        textObj.transform.Rotate(new Vector3(0, 180, 0));
    }

    private void UpdatePlaneColor()
    {
        Color planeColor = Color.cyan;

        switch(arPlane.classification)
        {
            case PlaneClassification.None:
                planeColor = Color.cyan;
                break;

            case PlaneClassification.Wall:
                planeColor = Color.green;
                break;

            case PlaneClassification.Floor:
                planeColor = Color.blue;
                break;

            case PlaneClassification.Ceiling:
                planeColor = Color.yellow;
                break;

            case PlaneClassification.Table:
                planeColor = Color.magenta;
                break;

            case PlaneClassification.Seat:
                planeColor = Color.red;
                break;

            case PlaneClassification.Door:
                planeColor = Color.white;
                break;

            case PlaneClassification.Window:
                planeColor = Color.clear;
                break;
        }

        planeColor.a = 0.33f;
        planeMeshRenderer.material.color = planeColor;
    }
}
