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

        StartCoroutine(startGame());
    }

    void Update()
    {
        if (timer.timeRemaining <= 0)
        {
            Lose();
            StartCoroutine(showText());
            gameEnd.enabled = true;
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
    }

    public void Lose()
    {
        playerMover.GetComponent<PlayerMovement>().canMove = false;
        mainCam.GetComponent<Interactor>().allowInteract = false;
        mainCam.GetComponent<PlayerCam>().canLook = false;
        timer.timerStart = false;
    }

    public void Retry()
    {
        
    }

    public void MainMenu()
    {
        
    }
}
