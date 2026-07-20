using UnityEngine;
using UnityEngine.InputSystem;

public class LookDirection : MonoBehaviour
{
    private Vector2 lookDirection = Vector2.right;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookDirection = context.ReadValue<Vector2>();

        if (lookDirection != Vector2.zero)
        {
            transform.right = lookDirection;
        }
    }
}
