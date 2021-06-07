using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARPlaceTheObject : MonoBehaviour
{

    public GameObject targetObject;

    private GameObject spawnObject;
    private ARRaycastManager raycastManager;
    //private List<GameObject> placedPrefabList = new List<GameObject>();

    //[SerializeField]
    //private int maxPrefabCount = 0;
    //private int placedPrefabCount;

    private Vector2 touchPosition;
    //public Transform target;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }
    private void Start()
    {
        //transform.LookAt(target);
    }
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount> 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;

    }
    
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitpose = hits[0].pose;

            if (spawnObject == null)
            {
                SpawnPrefab(hitpose);
            }
            else
            {
                spawnObject.transform.position = hitpose.position;
            }
        }
    }
    private void SpawnPrefab(Pose hitpose)
    {
        spawnObject = (Instantiate(targetObject, hitpose.position, hitpose.rotation));
    }
}
