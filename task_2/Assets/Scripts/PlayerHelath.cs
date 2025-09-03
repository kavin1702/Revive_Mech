using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    public  TextMeshProUGUI healthText;
    public int maxHealth = 100;
    private int currentHealth;



    void Start()
    {
   
        currentHealth = maxHealth;
      
        UpdateUI();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("Car hit the player!");
            int damage = Mathf.RoundToInt(collision.relativeVelocity.magnitude * 5);
            TakeDamage(damage);
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateUI();

        if (currentHealth == 0)
        {
            Debug.Log("Player is dead!");
        }
    }

    void UpdateUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }
}
