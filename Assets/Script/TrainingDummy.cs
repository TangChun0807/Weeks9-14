using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TrainingDummy : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public UnityEvent onHit;

    public SpriteRenderer dummyRenderer;

    public float respawnTime = 0.25f;

    private Coroutine respawnCoroutine;

    void Start()
    {
        // Start the dummy at full health
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        // Do not take damage while the dummy is already dead
        if (currentHealth <= 0)
        {
            return;
        }

        // Remove one health
        currentHealth -= 1;

        Debug.Log(gameObject.name + " Health: " + currentHealth);

        // Call all On Hit responses in the Inspector
        onHit.Invoke();

        // Start respawning when health reaches zero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Stop an old respawn coroutine if one is already running
        if (respawnCoroutine != null)
        {
            StopCoroutine(respawnCoroutine);
        }

        // Start the respawn coroutine
        respawnCoroutine = StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        // Hide the dummy
        dummyRenderer.enabled = false;

        // Wait before bringing the dummy back
        yield return new WaitForSeconds(respawnTime);

        // Reset health
        currentHealth = maxHealth;

        // Show the dummy again
        dummyRenderer.enabled = true;

        // The coroutine is finished
        respawnCoroutine = null;
    }
}