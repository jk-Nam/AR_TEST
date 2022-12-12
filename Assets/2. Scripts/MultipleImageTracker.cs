using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultipleImageTracker : MonoBehaviour
{
    private ARTrackedImageManager trackedImageManager;

    [SerializeField] private GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedObjects;

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        spawnedObjects = new Dictionary<string, GameObject>();

        foreach (GameObject obj in placeablePrefabs)
        {
            GameObject newObject = Instantiate(obj);
            newObject.name = obj.name;
            newObject.SetActive(false);

            spawnedObjects.Add(newObject.name, newObject);
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OntrackedImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OntrackedImageChanged;
    }

    private void OntrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateSpawnObject(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateSpawnObject(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedObjects[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateSpawnObject(ARTrackedImage trackedImage)
    {
        string referenceImageName = trackedImage.referenceImage.name;

        spawnedObjects[referenceImageName].transform.position = trackedImage.transform.position;
        spawnedObjects[referenceImageName].transform.rotation = trackedImage.transform.rotation;

        spawnedObjects[referenceImageName].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"There are {trackedImageManager.trackables.count} Images being tracked");

        foreach (var trackedImage in trackedImageManager.trackables)
        {
            Debug.Log($"Image : {trackedImage.referenceImage.name} is at" + $"{trackedImage.transform.position}");
        }
    }
}
