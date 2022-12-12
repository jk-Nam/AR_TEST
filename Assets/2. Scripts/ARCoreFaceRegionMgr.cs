using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using Unity.Collections;

public class ARCoreFaceRegionMgr : MonoBehaviour
{
    public GameObject go_nosePrefab;
    public GameObject go_leftHeadPrefab;
    public GameObject go_rightHeadPrefab;

    private GameObject go_noseObject;
    private GameObject go_leftHeadObject;
    private GameObject go_RightHeadObject;

    private ARFaceManager arFaceManager;
    private ARSessionOrigin sessionOrigin;

    private NativeArray<ARCoreFaceRegionData> faceRegions;

    // Start is called before the first frame update
    void Start()
    {
        arFaceManager = GetComponent<ARFaceManager>();
        sessionOrigin = GetComponent<ARSessionOrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        ARCoreFaceSubsystem subsystem = (ARCoreFaceSubsystem)arFaceManager.subsystem;

        foreach(ARFace face in arFaceManager.trackables)
        {
            subsystem.GetRegionPoses(face.trackableId, Allocator.Persistent, ref faceRegions);

            foreach (ARCoreFaceRegionData faceRegion in faceRegions)
            {
                ARCoreFaceRegion regionType = faceRegion.region;

                if (regionType == ARCoreFaceRegion.NoseTip)
                {
                    if (!go_noseObject)
                    {
                        go_noseObject = Instantiate(go_nosePrefab, sessionOrigin.trackablesParent);
                    }

                    go_noseObject.transform.localPosition = faceRegion.pose.position;
                    go_noseObject.transform.localRotation = faceRegion.pose.rotation;
                }
                else if (regionType == ARCoreFaceRegion.ForeheadLeft)
                {
                    if (!go_leftHeadObject)
                    {
                        go_leftHeadObject = Instantiate(go_leftHeadPrefab, sessionOrigin.trackablesParent);
                    }

                    go_leftHeadObject.transform.localPosition = faceRegion.pose.position;
                    go_leftHeadObject.transform.localRotation = faceRegion.pose.rotation;
                }
                else if (regionType == ARCoreFaceRegion.ForeheadRight)
                {
                    if (!go_RightHeadObject)
                    {
                        go_RightHeadObject = Instantiate(go_rightHeadPrefab, sessionOrigin.trackablesParent);
                    }

                    go_RightHeadObject.transform.localPosition = faceRegion.pose.position;
                    go_RightHeadObject.transform.localRotation = faceRegion.pose.rotation;
                }
            }
        }
    }
}
