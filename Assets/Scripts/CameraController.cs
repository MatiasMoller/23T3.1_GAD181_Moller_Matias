using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2.0f;
    [SerializeField] private float maxYAngle = 80.0f;

    private float rotationX = 0;

    private void Update()
    {
        // Get mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the camera based on mouse input
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.parent.Rotate(Vector3.up * mouseX * sensitivity);
    }
}
