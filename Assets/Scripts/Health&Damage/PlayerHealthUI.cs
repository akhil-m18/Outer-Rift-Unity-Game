using UnityEngine;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    public Health playerHealth;
    public TextMeshProUGUI healthText;

    private int maximumHealth;

    void Start()
    {
        if (playerHealth != null)
        {
            maximumHealth = playerHealth.maximumHealth;
        }
    }

    void Update()
    {
        if (playerHealth != null)
        {
            maximumHealth = playerHealth.maximumHealth;
            healthText.text = "HP: " + playerHealth.currentHealth + " / " + maximumHealth;
        }
        else
        {
            healthText.text = "HP: 0 / " + maximumHealth;
        }
    }
}