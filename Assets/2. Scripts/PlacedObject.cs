using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacedObject : MonoBehaviour
{
    [SerializeField] private GameObject go_cubeSelected;

    private static PlacedObject selectedObject;

    public static PlacedObject SelectedObject
    {
        get => selectedObject;
        set
        {
            if (selectedObject == value)
                return;

            if (selectedObject != null)
                selectedObject.go_cubeSelected.SetActive(false);

            selectedObject = value;
            if (value != null)
                value.go_cubeSelected.SetActive(true);
        }
    }

    public bool IsSelected
    {
        get => SelectedObject == this;
    }

    // Start is called before the first frame update
    void Awake()
    {
        go_cubeSelected.SetActive(false);
    }

    public void OnPointerDrag(BaseEventData bed)
    {
        if (IsSelected)
        {
            PointerEventData ped = (PointerEventData)bed;
            if (ObjectTracingMgr.Raycast(ped.position, out Pose hitPose))
            {
                transform.position = hitPose.position;
            }
        }
    }
}
