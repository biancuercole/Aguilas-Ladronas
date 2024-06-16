using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int levelIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D player)
    {
        changeLevel(levelIndex);
    }

    public void changeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
