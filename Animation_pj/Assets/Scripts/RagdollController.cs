using UnityEngine;
using UnityEngine.InputSystem;

public class RagdollController : MonoBehaviour
{
    public Animator animator;
    public CharacterController characterController;
    public MonoBehaviour movementController; // Drag ThirdPersonController here

    private Rigidbody[] boneBodies;
    private Collider[] boneColliders;
    private Collider[] rootColliders;

    void Awake()
    {
        if (!animator) animator = GetComponentInChildren<Animator>();
        if (!characterController) characterController = GetComponent<CharacterController>();

        rootColliders = GetComponents<Collider>();

        var bodyList = new System.Collections.Generic.List<Rigidbody>();
        foreach (var rb in GetComponentsInChildren<Rigidbody>(true))
        {
            if (rb.transform != transform)
                bodyList.Add(rb);
        }
        boneBodies = bodyList.ToArray();

        var colList = new System.Collections.Generic.List<Collider>();
        foreach (var col in GetComponentsInChildren<Collider>(true))
        {
            if (col.transform != transform)
                colList.Add(col);
        }
        boneColliders = colList.ToArray();

        SetRagdoll(false);
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SetRagdoll(true);
        }
    }

    public void SetRagdoll(bool ragdollEnabled)
    {
        if (animator) animator.enabled = !ragdollEnabled;
        if (characterController) characterController.enabled = !ragdollEnabled;
        if (movementController) movementController.enabled = !ragdollEnabled;

        foreach (var col in rootColliders)
            col.enabled = !ragdollEnabled;

        foreach (var rb in boneBodies)
        {
            rb.isKinematic = !ragdollEnabled;
            rb.detectCollisions = ragdollEnabled;
            if (ragdollEnabled)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.WakeUp();
            }
        }

        foreach (var col in boneColliders)
            col.enabled = ragdollEnabled;
    }
}