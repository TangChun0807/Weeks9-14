using UnityEngine;
using UnityEngine.Events;

public class TrainingDummy : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    // UnityEvent that happens whenever this dummy is hit.
    // Different dummies can have different responses in the Inspector.
    public UnityEvent onHit;

    void Start()
    {
        // Give the dummy full health when the game begins.
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        // Do not take more damage after reaching zero health.
        if (currentHealth <= 0)
        {
            return;
        }

        // Remove one health when attacked.
        currentHealth -= 1;

        Debug.Log(gameObject.name + " Health: " + currentHealth);

        // Run the functions connected to On Hit in the Inspector.
        onHit.Invoke();

        // Check whether the dummy has died.
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Disable the dummy when its health reaches zero.
        gameObject.SetActive(false);
    }
}