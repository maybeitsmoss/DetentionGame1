using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerMover;
    public Camera mainCam;
    public Timer timer;
    public Canvas gameEnd;

    public TextMeshProUGUI endText;
    public Button mainMenu;
    public Button retry;

    public Canvas fadeIn;


    public Canvas gameWin;
    public TextMeshProUGUI timerReport;
    public TextMeshProUGUI escapeReport;


    public AudioSource windowShot;
    public AudioSource doorOpen;
    public AudioSource ventOpen;
    public AudioSource backgroundMusic;
    //public AudioSource countdown;

    private bool hasLost = false;
    //public AudioSource footsteps;
    //private bool isPlayingFootsteps = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        playerMover.GetComponent<PlayerMovement>().canMove = false;
        mainCam.GetComponent<Interactor>().allowInteract = false;
        mainCam.GetComponent<PlayerCam>().canLook = false;
        timer.timerStart = false;
        gameEnd.enabled = false;

        endText.enabled = false;
        mainMenu.gameObject.SetActive(false);
        retry.gameObject.SetActive(false);
        gameWin.enabled = false;

        StartCoroutine(startGame());
    }

    void Update()
    {
        
        if (timer.timeRemaining <= 0 && hasLost == false)
        {
            Lose();
            StartCoroutine(showText());
            gameEnd.enabled = true;
            hasLost = true;
            //doorOpen.Play();
        }

        
    }

    IEnumerator showText()
    {
        yield return new WaitForSeconds(1.5f);

        endText.enabled = true;
        mainMenu.gameObject.SetActive(true);
        retry.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(1.5f);

        playerMover.GetComponent<PlayerMovement>().canMove = true;
        mainCam.GetComponent<Interactor>().allowInteract = true;
        mainCam.GetComponent<PlayerCam>().canLook = true;
        timer.timerStart = true;
        fadeIn.enabled = false;
    }

    public void Lose()
    {
        playerMover.GetComponent<PlayerMovement>().canMove = false;
        mainCam.GetComponent<Interactor>().allowInteract = false;
        mainCam.GetComponent<PlayerCam>().canLook = false;
        timer.timerStart = false;


        backgroundMusic.Stop();
        doorOpen.Play();
        
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;

     
    }

    public void doorWin()
    {
        playerMover.GetComponent<PlayerMovement>().canMove = false;
        mainCam.GetComponent<Interactor>().allowInteract = false;
        mainCam.GetComponent<PlayerCam>().canLook = false;
        timer.timerStart = false;

        backgroundMusic.Stop();
        doorOpen.Play();
        gameWin.enabled = true;
        timerReport.text = "IN " + (60 - Mathf.FloorToInt(timer.timeRemaining)) + " SECONDS";
        escapeReport.text = "DOOR";

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

      


    }

    public void ventWin()
    {
        playerMover.GetComponent<PlayerMovement>().canMove = false;
        mainCam.GetComponent<Interactor>().allowInteract = false;
        mainCam.GetComponent<PlayerCam>().canLook = false;
        timer.timerStart = false;

        backgroundMusic.Stop();
        ventOpen.Play();
        gameWin.enabled = true;
        timerReport.text = "IN " + (60 - Mathf.FloorToInt(timer.timeRemaining)) + " SECONDS";
        escapeReport.text = "VENT";

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void windowWin()
    {
        playerMover.GetComponent<PlayerMovement>().canMove = false;
        mainCam.GetComponent<Interactor>().allowInteract = false;
        mainCam.GetComponent<PlayerCam>().canLook = false;
        timer.timerStart = false;

        backgroundMusic.Stop();
        windowShot.Play();
        gameWin.enabled = true;
        timerReport.text = "IN " + (60 - Mathf.FloorToInt(timer.timeRemaining)) + " SECONDS";
        escapeReport.text = "WINDOW";

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        
    }

    public void Retry()
    {
        SceneManager.LoadScene("Intro");
    }

    public void MainMenu()
    {
        
    }
}
