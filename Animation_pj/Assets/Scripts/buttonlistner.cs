using UnityEngine;
using UnityEngine.InputSystem;

public class buttonlistner : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.bKey.wasPressedThisFrame)
        {
            animator.SetTrigger("Bow");
        }
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            animator.SetTrigger("Wave");
        }
    }
}