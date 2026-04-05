using UnityEngine;

public class Laptop : MonoBehaviour
{

    //freeze the player movement
    //transition the view to the new camera
    //show the computer screen (canvas enabled)
    //variable for laptop on, hard drive plugged in and THEN you can interact with computer exit and leave

    public bool laptopOn = false;
    public Camera LaptopCamera;
    public Camera mainCam;

    public GameObject Keypad;

    public GameObject playerMover;

    public  GameObject crossHair;

    private bool keepTime = false;

    public Timer timer;

    public Canvas timerCanvas;
    //public float timeCounter = 0f;
    //public int seconds;
    public GameObject player;

    public AudioSource footsteps1;
    public AudioSource countdown1;


    //public Button exitButton;

    void Start()
    {
        Keypad.SetActive(false);
        LaptopCamera.enabled = false;

        //timerCanvas.worldCamera = mainCam;
        //Keypad.GetComponent<Keypad>().enabled = false;
    }

     public void OnUnlock()
    {
        laptopOn = true;
        Debug.Log("unlocked!!");

        LaptopCamera.enabled = true;
        //mainCam.enabled = false;
        //timerCanvas.worldCamera = LaptopCamera;
        //mainCam.enabled = false;

        Keypad.SetActive(true);
        crossHair.SetActive(false);


        mainCam.GetComponent<PlayerCam>().canLook = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        playerMover.GetComponent<PlayerMovement>().canMove = false;
        mainCam.GetComponent<Interactor>().allowInteract = false;

        //timeCounter = 0f;
        //seconds = 0;
        keepTime = true;


        
        
        //Keypad.GetComponent<Keypad>().enabled = true;

    }


    public void Update()
    {
        if(Input.GetMouseButtonDown(1) && laptopOn == true)
        {

            //laptopOn = false;
            //mainCam.enabled = true;
            LaptopCamera.enabled = false;
            //timerCanvas.worldCamera = mainCam;
            //mainCam.enabled = true;

            crossHair.SetActive(true);

            mainCam.GetComponent<PlayerCam>().canLook = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerMover.GetComponent<PlayerMovement>().canMove = true;
            mainCam.GetComponent<Interactor>().allowInteract = true;

            //timer.SubtractTime(seconds - 1);
            keepTime = false;

            
        }

        if (keepTime == true)
        {
            timer.timeRemaining -= Time.deltaTime;

            if (timer.timeRemaining <= 4 && timer.isPlayingFootsteps == false)
            {
                footsteps1.Play();
                timer.isPlayingFootsteps = true;
            }
            

            //timeCounter += Time.deltaTime;
            
            //seconds = Mathf.FloorToInt(timeCounter % 60);
        }
        if (timer.timeRemaining <= 10 && timer.isPlayingCountdown == false)
        {
            countdown1.Play();
            timer.isPlayingCountdown = true;
        }
        if (timer.timeRemaining <= 0 && footsteps1.isPlaying == true)
        {
            footsteps1.Stop();
                //doorOpen.Play();
        }
        if (timer.timeRemaining <= 0 && countdown1.isPlaying == true)
        {
            countdown1.Stop();
                //doorOpen.Play();
        }
        
    }

  
        //player can click the button to exit and come back
        //permanent button to access laptop screen for the rest of the round
        //freeze player movement
        //transition the view to the new camera
        //show the computer screen (canvas enabled)



}
