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
    //public GameObject player


    //public Button exitButton;

    void Start()
    {
        Keypad.SetActive(false);
        LaptopCamera.enabled = false;
        //Keypad.GetComponent<Keypad>().enabled = false;
    }

     public void OnUnlock()
    {
        laptopOn = true;
        Debug.Log("unlocked!!");

        LaptopCamera.enabled = true;
        //mainCam.enabled = false;

        Keypad.SetActive(true);
        crossHair.SetActive(false);


        mainCam.GetComponent<PlayerCam>().canLook = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        playerMover.GetComponent<PlayerMovement>().canMove = false;
        mainCam.GetComponent<Interactor>().allowInteract = false;
        
        //Keypad.GetComponent<Keypad>().enabled = true;

    }


    public void Update()
    {
        if(Input.GetMouseButtonDown(1) && laptopOn == true)
        {

            //laptopOn = false;
            LaptopCamera.enabled = false;
            //mainCam.enabled = true;

            crossHair.SetActive(true);

            mainCam.GetComponent<PlayerCam>().canLook = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerMover.GetComponent<PlayerMovement>().canMove = true;
            mainCam.GetComponent<Interactor>().allowInteract = true;

            
        }
    }

  
        //player can click the button to exit and come back
        //permanent button to access laptop screen for the rest of the round
        //freeze player movement
        //transition the view to the new camera
        //show the computer screen (canvas enabled)



}
