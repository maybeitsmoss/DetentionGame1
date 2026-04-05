using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class drawers : MonoBehaviour
{
    public GameObject drawer1;
    public GameObject drawer2;
    public GameObject drawer3;
    public GameObject drawer4;

    public GameObject usb;
    public GameObject gun;
    public GameObject doorKey;

    public AudioSource openDrawer;

    /*private bool open1 = false;
    private bool open2 = false;
    private bool open3 = false;
    private bool open4 = false;*/

    public void Start()
    {
        usb.GetComponent<Rigidbody>().isKinematic = true;
        gun.GetComponent<Rigidbody>().isKinematic = true;
        doorKey.GetComponent<Rigidbody>().isKinematic = true;
        usb.SetActive(false);
        gun.SetActive(false);
        doorKey.SetActive(false);
    }

    public void OnUnlock()
    {
        Debug.Log("unlocked!!");
        //GetComponent<Animator>().SetTrigger("open");
    }



    public void drawer1open()
    {
        if (drawer2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("drawer2open"))
        {
            drawer2.GetComponent<Animator>().SetTrigger("drawer2close");
            //open2 = false;
        }
        if (drawer3.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("drawer3open"))
        {
            drawer3.GetComponent<Animator>().SetTrigger("drawer3close");
            //open3 = false;
        }
        if (drawer4.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("drawer4open"))
        {
            drawer4.GetComponent<Animator>().SetTrigger("drawer4close");
            //open4 = false;
        }

        openDrawer.Play();
        GetComponent<Animator>().SetTrigger("open");
        StartCoroutine(showUsb());

        //open1 = true;
    }

    IEnumerator showUsb()
    {
        yield return new WaitForSeconds(0.75f);
        usb.SetActive(true);
        usb.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void drawer2open()
    {
        if (drawer1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("drawerOpen"))
        {
            drawer1.GetComponent<Animator>().SetTrigger("close");
            //open1 = false;
        }
        if (drawer3.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("drawer3open"))
        {
            drawer3.GetComponent<Animator>().SetTrigger("drawer3close");
            //open3 = false;
        }
        if (drawer4.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("drawer4open"))
        {
            drawer4.GetComponent<Animator>().SetTrigger("drawer4close");
            //open4 = false;
        }

        openDrawer.Play();
        GetComponent<Animator>().SetTrigger("drawer2open");
        StartCoroutine(showGun());
        //open2 = true;
    }

    IEnumerator showGun()
    {
        yield return new WaitForSeconds(0.75f);

        gun.SetActive(true);
        gun.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void drawer3open()
    {
        if (drawer1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("drawerOpen"))
        {
            drawer1.GetComponent<Animator>().SetTrigger("close");
            //open1 = false;
        }
        if (drawer2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("drawer2open"))
        {
            drawer2.GetComponent<Animator>().SetTrigger("drawer2close");
            //open2 = false;
        }
        if (drawer4.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("drawer4open"))
        {
            drawer4.GetComponent<Animator>().SetTrigger("drawer4close");
            //open4 = false;
        }

        openDrawer.Play();
        GetComponent<Animator>().SetTrigger("drawer3open");
        StartCoroutine(showDoorKey());
        //open3 = true;
    }

    IEnumerator showDoorKey()
    {
        yield return new WaitForSeconds(0.75f);

        doorKey.SetActive(true);
        doorKey.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void drawer4open()
    {
        if (drawer1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("drawerOpen"))
        {
            drawer1.GetComponent<Animator>().SetTrigger("close");
            //open1 = false;
        }
        if (drawer2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("drawer2open"))
        {
            drawer2.GetComponent<Animator>().SetTrigger("drawer2close");
            //open2 = false;
        }
        if (drawer3.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("drawer3open"))
        {
            drawer3.GetComponent<Animator>().SetTrigger("drawer3close");
            //open3 = false;
        }

        openDrawer.Play();
        GetComponent<Animator>().SetTrigger("drawer4open");
        //open4 = true;
    }

}
