using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Velocidad de la bala
    [SerializeField] private float lifetime = 5f; // Tiempo de vida de la bala antes de destruirse

    void Start()
    {
        // Destruir la bala después de un tiempo para evitar que queden balas no deseadas en la escena
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Mover la bala hacia adelante en la dirección en la que fue disparada
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la bala ha colisionado con el jugador
        if (other.CompareTag("Player"))
        {
            // Acceder al script de salud del jugador y reducir la salud
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // Ajusta el daño según sea necesario
            }

            // Destruir la bala después de impactar
            Destroy(gameObject);
        }

        // Puedes agregar más lógica aquí para otras colisiones, como con el entorno u otros enemigos
    }
}
