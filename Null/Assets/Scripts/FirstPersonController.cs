using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour {

    public InputActionAsset InputActions;

    [Header("Movement")]
    private InputAction _moveAction;
    private InputAction _lookAction;
    private InputAction _crouchAction;
    private InputAction _sprintAction;
    public float walkSpeed = 6f;
    public float walkMod = 0.5f;
    public float sprintMod = 2f;

    [Header("Camera")]
    public Transform cameraTransform;
    public float mouseSens = 5f;
    public float maxLookAngle = 89f;
    float RotX = 0f;

    private Vector2 _moveAmt;

    Rigidbody rb;
    bool canMove = false;

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _crouchAction = InputSystem.actions.FindAction("Crouch");
        _sprintAction = InputSystem.actions.FindAction("Sprint");

        rb = GetComponent<Rigidbody>();

        
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Move();

        if (_sprintAction.IsPressed())
        {
            Sprint();
        }


        /*if (canMove)
        {
            
        }
        Move();*/
    }

    private void Update()
    {
        _moveAmt = _moveAction.ReadValue<Vector2>();

        if (_crouchAction.WasPressedThisFrame())
        {
            Crouch();
        }

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
        rb.MovePosition(rb.position + transform.forward * _moveAmt.y * walkSpeed * Time.deltaTime);
        rb.MovePosition(rb.position + transform.right * _moveAmt.x * walkSpeed * Time.deltaTime);

        //Old input controls
        /*float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = (transform.forward * v + transform.right * h).normalized;
        Vector3 moveVelocity = inputDirection * walkSpeed;
        Vector3 currentVelocity = rb.linearVelocity;

        rb.linearVelocity = new Vector3(moveVelocity.x, currentVelocity.y, moveVelocity.z);*/
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

    public void Crouch()
    {

    }

    public void Sprint()
    {

    }
}
