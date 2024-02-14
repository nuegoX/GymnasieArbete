using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 3f; // Adjust the speed as needed

    void Update()
    {
        // Rotate the object continuously around its up axis (Y-axis)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
