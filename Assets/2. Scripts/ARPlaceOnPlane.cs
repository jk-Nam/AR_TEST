using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceOnPlane : MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public GameObject go_placeObject;

    private GameObject go_spawnObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateCenterObject();
        PlaceObjectByTocuh();

    }

    private void PlaceObjectByTocuh()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;


                if (!go_spawnObject)
                {
                    go_spawnObject = Instantiate(go_placeObject, hitPose.position, hitPose.rotation);
                }
                else
                {
                    go_spawnObject.transform.position = hitPose.position;
                    go_spawnObject.transform.rotation = hitPose.rotation;
                }
            }
        }
    }

    private void UpdateCenterObject()
    {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycaster.Raycast(screenCenter, hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            Pose placementPose = hits[0].pose;
            go_placeObject.SetActive(true);
            go_placeObject.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            go_placeObject.SetActive(false);
        }
    }
}
