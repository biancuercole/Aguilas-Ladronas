using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // Prefab de la bala
    [SerializeField] private Transform firePoint; // Punto desde donde se disparan las balas
    [SerializeField]private float shootingRange = 10f; // Distancia a la cual el enemigo comienza a disparar
    private float fireRate = 1f; // Intervalo de tiempo entre disparos

    private Transform player;
    private bool isPlayerInRange = false;
    private Coroutine shootingCoroutine;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Asumiendo que el jugador tiene la etiqueta "Player"
    }

    void Update()
    {
        CheckPlayerDistance();
    }

    void CheckPlayerDistance()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= shootingRange && !isPlayerInRange)
        {
            isPlayerInRange = true;
            StartShooting();
        }
        else if (distanceToPlayer > shootingRange && isPlayerInRange)
        {
            isPlayerInRange = false;
            StopShooting();
        }
    }

    void StartShooting()
    {
        if (shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(Shoot());
        }
    }

    void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            FireProjectile();
            yield return new WaitForSeconds(fireRate);
        }
    }

    void FireProjectile()
    {
        Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
    }
}
