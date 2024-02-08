using UnityEngine;

public class ToggleModes : MonoBehaviour
{
    public Camera mainCamera;
    public Light flashlight;
    public Light flashlight2;

    private bool isMode1 = true; // Track the current mode

    void Start()
    {
        // Initialize the starting values
        SetMode(isMode1);
    }

    void Update()
    {
        // Check for E key press
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Toggle between modes
            isMode1 = !isMode1;

            // Set the appropriate mode
            SetMode(isMode1);
        }
    }

    void SetMode(bool mode)
    {
        if (mode)
        {
            mainCamera.fieldOfView = 57f;
            flashlight.intensity = 0f;
            flashlight2.intensity = 0f;
        }
        else
        {

            mainCamera.fieldOfView = 10f;
            flashlight.intensity = 1.5f;
            flashlight2.intensity = 1.5f;
        }
    }
}
