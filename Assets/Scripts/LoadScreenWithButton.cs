using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenWithButton : MonoBehaviour
{
    public int sceneIndex = 0;
    //Loading the scene after clickng the button
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadScene(sceneIndex);
        }
    }
}
