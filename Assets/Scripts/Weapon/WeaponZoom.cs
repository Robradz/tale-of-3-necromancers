using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float defaultFOV = 60f;
    [SerializeField] float zoomFOV = 40f;
    [SerializeField] float defaultSense = 1f;
    [SerializeField] float zoomSense = 0.67f;
    bool zoomed = false;

    RigidbodyFirstPersonController FPController;

    private void OnEnable()
    {
        FPController = FindObjectOfType<RigidbodyFirstPersonController>();
        FPController.mouseLook.XSensitivity = defaultSense;
        FPController.mouseLook.YSensitivity = defaultSense;
        FPCamera.fieldOfView = defaultFOV;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ToggleZoom();
        }
    }

    private void ToggleZoom()
    {
        if (!zoomed)
        {
            FPController.mouseLook.XSensitivity = zoomSense;
            FPController.mouseLook.YSensitivity = zoomSense;
            FPCamera.fieldOfView = zoomFOV;
            zoomed = true;
        }
        else
        {
            FPController.mouseLook.XSensitivity = defaultSense;
            FPController.mouseLook.YSensitivity = defaultSense;
            FPCamera.fieldOfView = defaultFOV;
            zoomed = false;
        }
    }
}
