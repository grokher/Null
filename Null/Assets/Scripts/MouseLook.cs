using UnityEngine;

public class MouseLook : MonoBehaviour
{
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
/*public Transform player;
    public float mouseSens = 15f;
    float cameraVertRot = 0f;
 * Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
 * float inputX = Input.GetAxis("Mouse X") * mouseSens;
        float inputY = Input.GetAxis("Mouse Y") * mouseSens;

        cameraVertRot -= inputY;
        cameraVertRot = Mathf.Clamp(cameraVertRot, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVertRot;

        player.Rotate(Vector3.up * inputX);