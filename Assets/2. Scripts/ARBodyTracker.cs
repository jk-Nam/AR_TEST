using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARBodyTracker : MonoBehaviour
{
    [SerializeField] private GameObject go_bodyPrefab;
    private GameObject go_bodyObject;

    private ARHumanBodyManager humanBodyMgr;

    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        humanBodyMgr = (ARHumanBodyManager)GetComponent<ARHumanBodyManager>();
    }

    private void OnEnable()
    {
        humanBodyMgr.humanBodiesChanged += OnHumanBodiesChanged;
    }

    private void OnDisable()
    {
        humanBodyMgr.humanBodiesChanged -= OnHumanBodiesChanged;
    }

    private void OnHumanBodiesChanged(ARHumanBodiesChangedEventArgs eventArgs)
    {
        foreach (ARHumanBody humanBody in eventArgs.added)
        {
            go_bodyObject = Instantiate(go_bodyPrefab, humanBody.transform);
        }

        foreach (ARHumanBody humanBody in eventArgs.updated)
        {
            if (go_bodyObject != null)
            {
                go_bodyObject.transform.position = humanBody.transform.position + offset;
                go_bodyObject.transform.rotation = humanBody.transform.rotation;
                go_bodyObject.transform.localScale = humanBody.transform.localScale;
            }
        }

        foreach (ARHumanBody humaBody in eventArgs.removed)
        {
            if (go_bodyObject != null)
                Destroy(go_bodyObject);
        }
    }
}
