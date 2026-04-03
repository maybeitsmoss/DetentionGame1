using UnityEngine;

public class drawers : MonoBehaviour
{
    public GameObject drawer1;
    public GameObject drawer2;
    public GameObject drawer3;
    public GameObject drawer4;

    /*private bool open1 = false;
    private bool open2 = false;
    private bool open3 = false;
    private bool open4 = false;*/

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

        GetComponent<Animator>().SetTrigger("open");
        //open1 = true;
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

        GetComponent<Animator>().SetTrigger("drawer2open");
        //open2 = true;
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

        GetComponent<Animator>().SetTrigger("drawer3open");
        //open3 = true;
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

        GetComponent<Animator>().SetTrigger("drawer4open");
        //open4 = true;
    }

}
