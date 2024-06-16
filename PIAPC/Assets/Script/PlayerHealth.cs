using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private int levelIndex;
    private float health;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator GetDamage(float damage)
    {
        float damageDuration = 5f;
        health -= damage;
        if (health > 0)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(damageDuration);
            spriteRenderer.color = Color.white;
        }
        else
        {
            ChangeLevel(levelIndex);
        }
    }

    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
