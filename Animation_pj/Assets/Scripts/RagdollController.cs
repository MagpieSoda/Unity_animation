using UnityEngine;
using UnityEngine.InputSystem;

public class RagdollController : MonoBehaviour
{
    // References to the character's animator, movement and controller components
    public Animator animator;
    public CharacterController characterController;
    public MonoBehaviour movementController;

    // Arrays to store all the Rigidbody and Collider components on the character's bones
    private Rigidbody[] boneBodies;
    private Collider[] boneColliders;
    private Collider[] rootColliders; // Stores colliders attached to the main character object

    void Awake()
    {
        // If the Animator has not been assigned, find it automatically
        if (!animator) animator = GetComponentInChildren<Animator>();

        // If the CharacterController has not been assigned, find it on this object
        if (!characterController) characterController = GetComponent<CharacterController>();

        // Get all colliders attached directly to the main character object
        rootColliders = GetComponents<Collider>();

        // Create a list to store the Rigidbody components on the character's bones
        var bodyList = new System.Collections.Generic.List<Rigidbody>();

        // Find all Rigidbody components on the character and its children
        foreach (var rb in GetComponentsInChildren<Rigidbody>(true))
        {
            // Ignore the Rigidbody attached to the main character object
            // Only add Rigidbodies belonging to the character's bones
            if (rb.transform != transform)
            bodyList.Add(rb);
        }

        // Convert the list of bone Rigidbodies into an array for later use
        boneBodies = bodyList.ToArray();

        // Create a list to store the colliders attached to the character's bones
        var colList = new System.Collections.Generic.List<Collider>();

        // Find all colliders on the character and its children, including inactive ones
        foreach (var col in GetComponentsInChildren<Collider>(true))
        {

            // Ignore colliders attached to the main character object
            // Only store the colliders belonging to the bones
            if (col.transform != transform)
                colList.Add(col);
        }

        // Convert the list of bone colliders into an array
        boneColliders = colList.ToArray();

        // Start with ragdoll mode turned off so the character can animate normally
        SetRagdoll(false);
    }

    void Update()
    {
        // Check if the R key has been pressed during this frame
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            // Turn ragdoll mode on when the R key is pressed
            SetRagdoll(true);
        }
    }

    public void SetRagdoll(bool ragdollEnabled)
    {
        // Enable or disable the Animator depending on whether ragdoll mode is active
        // The Animator is turned off when ragdoll mode is enabled
        if (animator) animator.enabled = !ragdollEnabled;

        // Disable the CharacterController while the ragdoll is active
        if (characterController) characterController.enabled = !ragdollEnabled;

        // Disable the normal movement script while the character is a ragdoll
        if (movementController) movementController.enabled = !ragdollEnabled;

        // Enable or disable the colliders on the main character object
        // These are disabled during ragdoll to prevent conflicts with bone colliders
        foreach (var col in rootColliders)
            col.enabled = !ragdollEnabled;

        // Loop through all the Rigidbody components attached to the character's bones
        foreach (var rb in boneBodies)
        {
            // Make the bones physics-controlled when ragdoll is enabled
            // Make them animation-controlled again when ragdoll is disabled
            rb.isKinematic = !ragdollEnabled;

            // Enable physics collisions for the bones during ragdoll mode
            rb.detectCollisions = ragdollEnabled;

            // Only reset the physics values when ragdoll is being enabled
            if (ragdollEnabled)
            {
                // Remove any existing movement from the bones
                rb.linearVelocity = Vector3.zero;

                // Remove any existing rotational movement from the bones
                rb.angularVelocity = Vector3.zero;

                // Wake up the Rigidbody so physics can start affecting it
                rb.WakeUp();
            }
        }
        // Enable the bone colliders when ragdoll mode is active
        // Disable them again when normal animation is being used
        foreach (var col in boneColliders)
            col.enabled = ragdollEnabled;
    }
}