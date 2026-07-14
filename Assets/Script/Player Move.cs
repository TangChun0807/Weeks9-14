
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Vector2 movementDirection = Vector2.zero;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if we have a Vector2 and we want to add the a Vector3
        //We can convert between them using (Vector3) in front of the Vector2
        transform.position += (Vector3)movementDirection * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("attack! " + context.phase);
            //hello world
        }

    }
}

