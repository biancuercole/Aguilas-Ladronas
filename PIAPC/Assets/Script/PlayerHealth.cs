using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10; // Salud máxima del jugador
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Aquí puedes manejar la muerte del jugador, como reiniciar el nivel o mostrar una pantalla de Game Over
        Debug.Log("Player died!");
        Destroy(gameObject);
    }
}
