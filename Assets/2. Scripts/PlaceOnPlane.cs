using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnPlane : MonoBehaviour
{
    [SerializeField] private GameObject[] go_placePrefab;
    [SerializeField] private Camera arCamera;
    [SerializeField] private LayerMask placeedObjectLayerMask;

    private Vector2 touchPos;
    private Ray ray;
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (!ObjectTracingMgr.TryGetInputPos(out touchPos))
            return;

        ray = arCamera.ScreenPointToRay(touchPos);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, placeedObjectLayerMask))
        {
            PlacedObject.SelectedObject = hit.transform.GetComponentInChildren<PlacedObject>();
            return;
        }

        PlacedObject.SelectedObject = null;

        if (ObjectTracingMgr.Raycast(touchPos, out Pose hitpose))
        {
            int index = Random.Range(0, go_placePrefab.Length);
            Instantiate(go_placePrefab[index], hitpose.position, hitpose.rotation);
        }
    }
}
