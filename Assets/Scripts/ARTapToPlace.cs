using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedObject;

    [SerializeField]
    private GameObject[] pObjs;

    private int currentObj = 0;

    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Start()
    {
        foreach (GameObject item in pObjs)
        {
            item.SetActive(false);
        }

        currentObj = 0;
        pObjs[currentObj].SetActive(true);
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitpos = hits[0].pose;
            selectedObject.transform.position = hitpos.position;
        }
    }

    public void ChangePObjs(int value)
    {
        pObjs[currentObj].SetActive(false);
        currentObj = value;
        pObjs[currentObj].SetActive(true);
    }
}