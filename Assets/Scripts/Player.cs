using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotationSpeed;

    float xRotation, yRotation;
    float mouseX, mouseY;

    [SerializeField]
    private Camera camera;
    [SerializeField] 
    private Transform orientation;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");


        yRotation += mouseX * rotationSpeed * Time.deltaTime;
        xRotation -= mouseY * rotationSpeed * Time.deltaTime;

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);
        controller.Move(move * Time.deltaTime * moveSpeed);
    }
}
