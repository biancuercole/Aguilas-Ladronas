using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private bool restart;
    [SerializeField] private int index;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            passLevel(index);
        }
    }

    public void passLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

}
