using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerCamera = GetComponent<Camera>();
    }

    // this will work in 3D perspective camera
    public float normalFOV = 60f;
    public float sprintFOV = 90f;
    public float smoothSpeed = 5f;
    public Camera playerCamera;
    private bool sprinting;
    void Update()
    {
        sprinting = Input.GetKey(KeyCode.LeftShift);

        // Smooth FOV transition
        float targetFOV = sprinting ? sprintFOV : normalFOV;

        playerCamera.fieldOfView = Mathf.Lerp(
            playerCamera.fieldOfView,
            targetFOV,
            Time.deltaTime * smoothSpeed
        );
    }

    // this will work in 2D orthographic camera
    public Transform target;
    public Vector3 offset;
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
        
    }
    
}
