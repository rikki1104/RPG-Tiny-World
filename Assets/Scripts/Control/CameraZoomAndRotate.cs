using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using RPG.Control;
using RPG.Core;
using UnityEngine;

public class CameraZoomAndRotate : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cmCamera;
    [SerializeField] float maxCameraZoom = 40f;
    [SerializeField] float minCameraZoom = 5f;

    float cameraDistance = 18f;

    void Start()
    {
        cmCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        cameraDistance = 30f;
    }

    void Update()
    {
        ZoomCamera();
        RotateCamera();
    }

    private void ZoomCamera()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            cameraDistance -= 5f;
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            cameraDistance += 5f;
        }
        
        cameraDistance = Mathf.Clamp(cameraDistance, minCameraZoom, maxCameraZoom);
        cmCamera.m_Lens.FieldOfView = cameraDistance;
    }

    private void RotateCamera()
    {
        float rotateSpeed = 5f;

        if (Input.GetMouseButton(2))
        {
            cmCamera.transform.eulerAngles += rotateSpeed * new Vector3(x: 0, y: Input.GetAxis("Mouse X"), z: 0);
        }
    }
}
