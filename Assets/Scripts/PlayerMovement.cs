using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float movementSpeed = 12f;
    private float pitch = 0.0f;

    private Camera playerCamera; 

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>(); 

    }

    private void Update()
    {
        // Get the mouse input for camera rotation.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player and the camera.
        transform.Rotate(Vector3.up * mouseX);
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f); // Limit the camera's vertical rotation.

        // Apply rotation to the camera.
        playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0, 0);

        // Get the input for character movement.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate the movement direction based on the camera's rotation.
        Vector3 moveDirection = (playerCamera.transform.forward * z + playerCamera.transform.right * x).normalized;

        // Apply movement to the character controller.
        controller.Move(moveDirection * movementSpeed * Time.deltaTime);
    }
}
