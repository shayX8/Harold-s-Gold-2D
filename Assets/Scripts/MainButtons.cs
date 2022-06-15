using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtons : MonoBehaviour
{
    public GameObject startButton;
    public GameObject instructionsButton;
    public GameObject exitButton;

    public GameObject instructionsText;
    public GameObject backButton;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void Instructions()
    {
        //Setting the Main buttons to be inactive and enabling the Instructions buttons and text
        startButton.SetActive(false);
        instructionsButton.SetActive(false);
        exitButton.SetActive(false);

        instructionsText.SetActive(true);
        backButton.SetActive(true);
    }
    public void backToMain()
    {
        //Setting the Main buttons to be active and disabling the Instructions buttons and text
        startButton.SetActive(true);
        instructionsButton.SetActive(true);
        exitButton.SetActive(true);

        instructionsText.SetActive(false);
        backButton.SetActive(false);
    }
}
