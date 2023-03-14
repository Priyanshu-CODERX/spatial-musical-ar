using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementReticle : MonoBehaviour
{
    //public GameObject Object;

    private ARSessionOrigin sessionOrigin;
    private ARRaycastManager raycastManager;

    [SerializeField]
    GameObject ReticlePrefab;

    private GameObject SpawnedReticle;
    private GameObject SpawnedObject;

    TrackableType RaycastMask;

    static List<ARRaycastHit> RaycastHits = new List<ARRaycastHit>();
    
    void Start()
    {
        sessionOrigin = GetComponent<ARSessionOrigin>();
        raycastManager = GetComponent<ARRaycastManager>();

        RaycastMask = TrackableType.PlaneWithinPolygon;
        SpawnedReticle = Instantiate(ReticlePrefab);
        SpawnedReticle.SetActive(false);
    }

    void Update()
    {
        var screenCenter = sessionOrigin.camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        if (raycastManager.Raycast(screenCenter, RaycastHits, RaycastMask))
        {
            Pose hitPose = RaycastHits[0].pose;
            SpawnedReticle.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
            SpawnedReticle.SetActive(true);
        }
    }

    public void PlaceObject(GameObject _MusicInstrument)
    {
        SpawnedObject = Instantiate(_MusicInstrument, SpawnedReticle.transform.position, SpawnedReticle.transform.rotation);
    }

    public void DisableReticle (bool isEnabled)
    {
        SpawnedReticle.SetActive(isEnabled);
    }

}
