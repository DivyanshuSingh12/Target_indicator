using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceManager : MonoBehaviour
{
    private PlaceIndicator placeIndicator;
    public GameObject objectToPlane;

    private GameObject newPlacedObject;

    public ARRaycastManager raycastManager;
    public GameObject objectToPlace;

    private GameObject placedObject;

    public Camera arCamera;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();
    }

    void Update()
    {
        Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;
                if (placedObject == null)
                {
                    placedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                }
                else
                {
                    placedObject.transform.position = hitPose.position;
                    placedObject.transform.rotation = hitPose.rotation;
                }
            }
        }
    }
}
