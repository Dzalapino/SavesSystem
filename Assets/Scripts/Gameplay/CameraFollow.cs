using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                 // The target to follow
    public float distance = 5.0f;            // Distance from the target
    public float height = 3.0f;              // Height above the target
    public float smoothSpeed = 10.0f;        // Smoothing speed for camera movement
    public float rotationSpeed = 5.0f;       // Rotation speed for camera

    private Vector3 offset;                  // Offset from the target

    private void Start()
    {
        // Calculate and store the offset from the target
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Calculate the desired position
        Vector3 targetPosition = target.position - target.forward * distance;
        targetPosition.y = target.position.y + height;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Rotate the camera to match the player's rotation
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
