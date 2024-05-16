using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform orientation;
    public float sensitivityX;
    public float sensitivityY;
    

    private float xRotation;
    private float yRotation;

    // void Start()
    // {
    //     Cursor.lockState = CursorLockMode.Locked;
    //     Cursor.visible = false;
    // }

    void Update()
    {
        // Get mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation =  Mathf.Clamp(xRotation, -90f, 90f);

        //  Camera rotate
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
