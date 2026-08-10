using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 movementDirection = Vector2.zero;

    void Update()
    {
        // Move the player using the movement value from PlayerInput
        transform.position +=
            (Vector3)movementDirection * moveSpeed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Store movement input from PlayerInput
        movementDirection = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        // Only run once when the input reaches the performed phase
        if (context.performed)
        {
            Debug.Log("Player Attack!");
        }
    }
}