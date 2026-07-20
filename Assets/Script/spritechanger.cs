using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    private int index = 0;

    void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[index];
        }
    }

    public void ChangeSprite(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        if (sprites.Length == 0)
        {
            return;
        }

        index++;

        if (index >= sprites.Length)
        {
            index = 0;
        }

        spriteRenderer.sprite = sprites[index];

        Debug.Log("Sprite changed to index: " + index);
    }
}