using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float timeBetween;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());   
    }

    IEnumerator Shoot ()
    {
        while (true)
        {
        yield return new WaitForSeconds(timeBetween);
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}
