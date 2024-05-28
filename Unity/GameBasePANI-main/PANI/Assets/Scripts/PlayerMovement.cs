using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Movimiento
    private Rigidbody rb;
    public float speed;

    // Camara
    public float mouseSensitivityX;
    public float mouseSensitivityY;
    private float xRotation;
    private float yRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate() // Usa FixedUpdate para cálculos físicos
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 movementDirection = (transform.forward * ver + transform.right * hor).normalized;
        rb.velocity = new Vector3(movementDirection.x * speed, rb.velocity.y, movementDirection.z * speed);
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
