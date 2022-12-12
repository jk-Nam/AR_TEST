using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARFaceSwitch : MonoBehaviour
{
    private ARFaceManager arFaceManager;

    private Material currentMaterial;
    public Material[] materials;

    private int switchCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        arFaceManager = GetComponent<ARFaceManager>();
        currentMaterial = arFaceManager.facePrefab.GetComponent<MeshRenderer>().material;
        //arFaceManager.facePrefab.GetComponent<MeshRenderer>().material = materials[0];
    }

    //private void SwitchFaces()
    //{
    //    foreach (ARFace face in arFaceManager.trackables)
    //    {
    //        face.GetComponent<MeshRenderer>().material = materials[switchCount];
    //    }

    //    switchCount = (switchCount + 1) % materials.Length;
    //}

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    SwitchFaces();
        //}

        foreach (ARFace face in arFaceManager.trackables)
        {
            face.GetComponent<MeshRenderer>().material = currentMaterial;
        }
    }

    public void UpdateFaceMaterial(Material _material)
    {
        currentMaterial = _material;
    }
}
