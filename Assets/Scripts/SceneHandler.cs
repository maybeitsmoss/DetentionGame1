using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class SceneHandler : MonoBehaviour
{
    public AudioSource music;
    public Canvas rulezCanvas;
    public Canvas menuCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rulezCanvas.enabled = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void GameRules()
    {
        rulezCanvas.enabled = true;
        menuCanvas.enabled = false;

        Debug.Log("Game Rules");
        //SceneManager.LoadScene("Rulez");
    }

    public void BackToMenu()
    {
        rulezCanvas.enabled = false;
        menuCanvas.enabled = true;
        //SceneManager.LoadScene("Menu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TITLE 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
