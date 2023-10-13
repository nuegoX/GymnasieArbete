using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float rotationSpeed = 50.0f;
    float maxRotationX = 60.0f;
    float minRotationX = 0.0f;

    // Update is called once per frame
    void Update()
    {
        float currentRotationX = transform.localEulerAngles.x;

        if (Input.GetKey(KeyCode.O) && currentRotationX > minRotationX)
        {
            float rotationAmount = Mathf.Min(rotationSpeed * Time.deltaTime, currentRotationX - minRotationX);
            transform.Rotate(Vector3.left * rotationAmount);
        }
        if (Input.GetKey(KeyCode.L) && currentRotationX < maxRotationX)
        {
            float rotationAmount = Mathf.Min(rotationSpeed * Time.deltaTime, maxRotationX - currentRotationX);
            transform.Rotate(Vector3.right * rotationAmount);
        }
    }
}
