using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Character myCharacter;
    public Transform playerCamera;
    public float mouseSensitivity = 2.0f;
    private float xRotation = 0f;

    void Start()
    {   
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        // Make the cursor invisible
        Cursor.visible = false;

        myCharacter = GetComponent<Character>();

        if (myCharacter == null)
        {
            Debug.LogError("Hey! I can't find the Character script on this object!");
        }
    }

    void Update()
    {
        // --- Movement Input ---
        // 1. Check for Sprint
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        // 2. Get WASD directions
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 3. Combine into a direction package
        Vector3 direction = transform.right * moveX + transform.forward * moveZ;

        // 4. Send the 'handshake' to the Character script (Direction + Sprint Status)
        myCharacter.Move(direction, isSprinting);

        // --- Jumping ---
        if (Input.GetButtonDown("Jump"))
        {
            myCharacter.Jump();
        }

        // -- Camera Movement --
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