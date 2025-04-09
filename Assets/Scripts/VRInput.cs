using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRInput : BaseInput
{
    public Camera eventCamera = null;

    public OVRInput.Button clickButton = OVRInput.Button.PrimaryIndexTrigger;
    public OVRInput.Controller controller = OVRInput.Controller.RTouch; // Changed to a specific controller (Right Touch)

    protected override void Awake()
    {
        // Ensure that BaseInputModule is correctly overridden
        GetComponent<BaseInputModule>().inputOverride = this;
    }

    public override bool GetMouseButton(int button)
    {
        // Use the correct button for VR input (e.g., PrimaryIndexTrigger)
        return OVRInput.Get(clickButton, controller);
    }

    public override bool GetMouseButtonDown(int button)
    {
        // Correctly handle the press event for VR controllers
        return OVRInput.GetDown(clickButton, controller);
    }

    public override bool GetMouseButtonUp(int button)
    {
        // Correctly handle the release event for VR controllers
        return OVRInput.GetUp(clickButton, controller);
    }

    public override Vector2 mousePosition
    {
        get
        {
            // Return the VR controller's position (if you want to implement mouse-like behavior)
            return new Vector2(eventCamera.pixelWidth / 2, eventCamera.pixelHeight / 2);
        }
    }
}
