using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float timeBetween;
    [SerializeField] private Transform player;
    [SerializeField] private float distance; 

    private bool isShooting;
    private bool isInRange;

    // Start is called before the first frame update
    void Start()
    {
        isShooting = false; 
        isInRange = false;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < distance)
        {
            if (!isShooting)
            {
                isShooting = true;
                isInRange = true;
                StartCoroutine(Shoot());
            }
        }
        else
        {
            isInRange = false;
        }
    }

    IEnumerator Shoot()
    {
        while (isInRange)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetween);
        }
        isShooting = false; // Reset isShooting when exiting the loop
    }
}
