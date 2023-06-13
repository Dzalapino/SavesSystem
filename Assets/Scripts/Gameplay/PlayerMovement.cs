using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;                 // Player movement speed
    public float rotationSpeed = 10f;        // Player rotation speed
    public float mouseSensitivity = 3f;      // Mouse sensitivity for rotation
    public float raycastDistance = 1f;       // Distance for raycasting collision detection

    private CharacterController controller;
    private Vector3 movement;                // Movement direction
    private float mouseX;                    // Mouse input for rotation
    private GameObject lastHitObject;        // Reference to the last hit object

    private Material[] originalMaterials;    // Original materials
    private Material[] highlightedMaterials; // Highlighted materials

    private bool isMouseButtonDown = false;

    private PlayerData playerData;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        playerData = SavesManager.Load("player_data");
        Debug.Log(playerData.name);
    }

    private void Update()
    {
        // Get input for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Normalize movement vector to prevent faster diagonal movement
        movement.Normalize();

        // Get input for mouse rotation
        mouseX = Input.GetAxis("Mouse X");

        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            isMouseButtonDown = true;
        }
    }

    private void FixedUpdate()
    {
        // Rotate the character horizontally based on mouse input
        transform.Rotate(Vector3.up * mouseX * mouseSensitivity);

        // Perform raycasting to detect collisions
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            // Check if the hit object is different from the last hit object
            if (hit.collider.gameObject != lastHitObject)
            {
                // Reset the highlighting on the last hit object
                if (lastHitObject != null)
                {
                    ResetHighlight();
                }

                // Store the current hit object
                lastHitObject = hit.collider.gameObject;

                // Check the tag of the hit object
                if (lastHitObject.CompareTag("Vendor_XP"))
                {
                    // Apply highlighting to the current hit object
                    HighlightObject(lastHitObject);

                    // Check if the left mouse button is clicked
                    if (isMouseButtonDown)
                    {
                        // Perform actions for Vendor_XP
                        Debug.Log("Vendor_XP selected and left mouse button clicked!");
                        isMouseButtonDown = false;
                    }
                }
                else if (lastHitObject.CompareTag("Vendor_Income"))
                {
                    // Apply highlighting to the current hit object
                    HighlightObject(lastHitObject);

                    // Check if the left mouse button is clicked
                    if (isMouseButtonDown)
                    {
                        // Perform actions for Vendor_Income
                        Debug.Log("Vendor_Income selected and left mouse button clicked!");
                        isMouseButtonDown = false;
                    }
                }
            }   
            else
            {
                // Check if the left mouse button is clicked
                if (isMouseButtonDown)
                {
                    // Perform actions for the last hit object
                    if (lastHitObject.CompareTag("Vendor_XP"))
                    {
                        Debug.Log("Vendor_XP left mouse button clicked again!");
                    }
                    else if (lastHitObject.CompareTag("Vendor_Income"))
                    {
                        Debug.Log("Vendor_Income left mouse button clicked again!");
                    }
                    isMouseButtonDown = false;
                }
            }
        }
        else
        {
            // Reset the highlighting if no collision is detected
            ResetHighlight();
            lastHitObject = null;
        }

        // Move the player using the CharacterController
        Vector3 moveDirection = transform.TransformDirection(movement);
        controller.Move(moveDirection * speed * Time.fixedDeltaTime);
    }

    private void HighlightObject(GameObject obj)
    {
        // Get all child mesh renderers of the combined object
        MeshRenderer[] childRenderers = obj.GetComponentsInChildren<MeshRenderer>();

        // Store the original materials
        originalMaterials = new Material[childRenderers.Length];
        highlightedMaterials = new Material[childRenderers.Length];

        for (int i = 0; i < childRenderers.Length; i++)
        {
            originalMaterials[i] = childRenderers[i].material;
            // Create a copy of the material and change the color to highlight the object
            Material highlightedMaterial = new Material(originalMaterials[i])
            {
                color = Color.yellow
            };
            highlightedMaterials[i] = highlightedMaterial;

            // Assign the highlighted material to the renderer
            childRenderers[i].material = highlightedMaterial;
        }
    }

    private void ResetHighlight()
    {
        // Reset the highlighting on the last hit object
        if (lastHitObject != null)
        {
            MeshRenderer[] childRenderers = lastHitObject.GetComponentsInChildren<MeshRenderer>();

            for (int i = 0; i < childRenderers.Length; i++)
            {
                // Restore the original material
                childRenderers[i].material = originalMaterials[i];
            }
        }
    }
}