using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirstPersonController : MonoBehaviour {

    [Header("Movement")]
    public float walkSpeed = 6f;
    public float walkMod = 0.5f;

    [Header("Camera")]
    public Transform cameraTransform;
    public float mouseSens = 5f;
    public float maxLookAngle = 89f;
    float RotX = 0f;

    Rigidbody rb;
    bool canMove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canMove)
                DisableController();
            else
                EnableController();
        }
        if (canMove)
        {
            Look();
        }
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputDirection = (transform.forward * v + transform.right * h).normalized;
        Vector3 moveVelocity = inputDirection * walkSpeed;
        Vector3 currentVelocity = rb.linearVelocity;

        rb.linearVelocity = new Vector3(moveVelocity.x, currentVelocity.y, moveVelocity.z);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens;

        transform.Rotate(0f, mouseX, 0f);

        RotX -= mouseY;
        RotX = Mathf.Clamp(RotX, -maxLookAngle, maxLookAngle);
        cameraTransform.localRotation = Quaternion.Euler(RotX, 0f, 0f);
    }

    public void DisableController()
    {
        canMove = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void EnableController()
    {
        canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
