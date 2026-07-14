using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivy = 500f;
    private float _xRotation = 0f;
     private float _yRotation = 0f;

    [SerializeField] private float _topClamp = -90f;
    [SerializeField] private float _bottomClamp = 90f;

    void Start()
    {
        // Lock the cursor to the screen 
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input from the player on both axes (left/right + top/down)
        float mouseXInput = Input.GetAxis("Mouse X") * _mouseSensitivy * Time.deltaTime;
        float mouseYInput = Input.GetAxis("Mouse Y") * _mouseSensitivy * Time.deltaTime;

        // Calculate rotation on the camera on the both axes
        _xRotation -= mouseYInput;
        _yRotation += mouseXInput;

        // Clamp camera rotation looking up and down
        _xRotation = Mathf.Clamp(_xRotation, _topClamp, _bottomClamp);

        // Apply all the calculations to the camera!
        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
    }
}