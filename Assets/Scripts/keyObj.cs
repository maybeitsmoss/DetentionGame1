using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class keyObj : MonoBehaviour
{
    public UnlockableObjects keyType;

    public GameObject target;

    public GameManager gameManager;

    public AudioSource phoneMessage;
    public AudioSource phoneRing;
    public AudioSource phoneHangUp;

    //public Canvas timer;

    public void Interact()
    {
        if (this.name == "gun")
        {
            transform.position = target.transform.position;
            this.transform.parent = target.transform;
            this.transform.localEulerAngles = new Vector3(270, 90, 90);

            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if (this.name == "Phone")
        {
            transform.position = target.transform.position;
            this.transform.parent = target.transform;
            this.transform.localEulerAngles = new Vector3(0, -90, 80);

            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<Rigidbody>().isKinematic = true;

            gameManager.backgroundMusic.volume  = 0.1f;
            phoneRing.Play();
            StartCoroutine(PhoneSFX());
        }
        else
        {
            transform.position = target.transform.position;
            this.transform.parent = target.transform;
            this.transform.localEulerAngles = new Vector3(0, 0, 0);

            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
        
        //this.GetComponent<Rigidbody>().SetActive(false);
    }

    IEnumerator PhoneSFX()
    {
        yield return new WaitForSeconds(0.3f);
        phoneMessage.Play();

        yield return new WaitForSeconds(14f);

        gameManager.backgroundMusic.volume = 0.26f;
    }

    public void Drop()
    {
        this.transform.parent = null;
        this.GetComponent<Collider>().enabled = true;
        this.GetComponent<Rigidbody>().isKinematic = false;

        if (this.name == "ball")
        {
            this.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.Impulse);
        }
        if (this.name == "Phone")
        {
            phoneHangUp.Play();
            gameManager.backgroundMusic.volume = 0.26f;
            phoneMessage.Stop();
        }
        //this.GetComponent<Rigidbody>().SetActive(true);
    }


}

public enum UnlockableObjects
{
    door, drawer1, drawer2, drawer3, drawer4, teachercabinet, supplycabinet, supplycabinet2, janitorcabinet, laptop, window, vent, toolbox, none
}