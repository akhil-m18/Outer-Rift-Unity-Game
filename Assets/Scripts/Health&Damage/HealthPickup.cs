using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healingAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        Health playerHealth = other.GetComponent<Health>();

        if (playerHealth != null && playerHealth.currentHealth < playerHealth.maximumHealth)
        {
            playerHealth.ReceiveHealing(healingAmount);
            Destroy(gameObject);
        }
    }
}