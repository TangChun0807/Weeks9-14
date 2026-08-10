using System.Collections;
using UnityEngine;

public class DummyHitReaction : MonoBehaviour
{
    public SpriteRenderer dummyRenderer;
    public float flashDuration = 0.2f;

    private Color originalColour;
    private Coroutine flashCoroutine;

    void Start()
    {
        // Save the original colour of the dummy
        originalColour = dummyRenderer.color;
    }

    public void StartFlash()
    {
        // Check if the flash coroutine is already running
        if (flashCoroutine != null)
        {
            // Stop the current flash before starting a new one
            StopCoroutine(flashCoroutine);
        }

        // Start the flash coroutine
        flashCoroutine = StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        int flashCount = 0;

        // Flash the dummy three times
        while (flashCount < 3)
        {
            // Change the dummy colour to red
            dummyRenderer.color = Color.red;

            // Wait before changing the colour back
            yield return new WaitForSeconds(flashDuration);

            // Change back to the original colour
            dummyRenderer.color = originalColour;

            // Wait before flashing again
            yield return new WaitForSeconds(flashDuration);

            flashCount++;
        }

        // The coroutine is finished
        flashCoroutine = null;
    }

    public void StopFlash()
    {
        // Check if the flash coroutine is running
        if (flashCoroutine != null)
        {
            // Stop the flash coroutine
            StopCoroutine(flashCoroutine);
            flashCoroutine = null;
        }

        // Change the dummy back to its original colour
        dummyRenderer.color = originalColour;
    }
}