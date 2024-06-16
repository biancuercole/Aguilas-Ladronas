using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private bool passLevel;
    private int levelIndex;

    void Update()
    {
        if (passLevel)
        {
            changeLevel(levelIndex);
        }
    }

    public void changeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
