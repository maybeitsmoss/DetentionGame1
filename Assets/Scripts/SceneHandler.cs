using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;


public class SceneHandler : MonoBehaviour
{
    public AudioSource music;
    public Canvas rulezCanvas;
    public Canvas menuCanvas;

    public Canvas fader;

    public Image fadeImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rulezCanvas.enabled = false;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1);
        fader.enabled = false;
    }

    public void StartGame()
    {
        StartCoroutine(LoadGame());
        //SceneManager.LoadScene("Intro");
    }

    IEnumerator LoadGame()
    {
        fader.enabled = true;
        fadeImage.GetComponent<Animator>().SetTrigger("fadeOut");

        yield return new WaitForSeconds(1);

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
