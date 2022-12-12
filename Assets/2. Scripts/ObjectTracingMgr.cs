using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectTracingMgr : MonoBehaviour
{
    private static ARRaycastManager theraycastMgr;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Start()
    {
        theraycastMgr = GameObject.FindObjectOfType<ARRaycastManager>();
    }

    public static bool Raycast(Vector2 screenPos, out Pose pose)
    {
        if (theraycastMgr.Raycast(screenPos, hits, TrackableType.All))
        {
            pose = hits[0].pose;
            return true;
        }
        else
        {
            pose = Pose.identity;
            return false;
        }
    }

    public static bool TryGetInputPos(out Vector2 pos)
    {
        pos = Vector2.zero;

        if (Input.touchCount == 0)
            return false;

        pos = Input.GetTouch(0).position;

        if (Input.GetTouch(0).phase != TouchPhase.Began)
            return false;

        return true;
    }
}
