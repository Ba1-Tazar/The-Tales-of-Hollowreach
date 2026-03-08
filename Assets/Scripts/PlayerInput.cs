using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Character myCharacter;
    public Transform playerCamera;
    public float mouseSensitivity = 2.0f;
    private float xRotation = 0f;

    void Start()
    {
        myCharacter = GetComponent<Character>();

        if (myCharacter == null)
        {
            Debug.LogError("Hey! I can't find the Character script on this object!");
        }
    }

    void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * moveX + transform.forward * moveZ;
        myCharacter.Move(direction);

        // Camera
        // 1. Get Mouse Input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // 2. Rotate Body Left/Right
        transform.Rotate(Vector3.up * mouseX);

        // 3. Rotate Camera Up/Down (with limits)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}