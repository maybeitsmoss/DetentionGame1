using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerManager : MonoBehaviour
{
    [Header("Setting Up The Opening Distance From The Base")]
    [SerializeField] public float MaxOpeningDistance = 1f;

    [Header("Setting Up The Speed Of Closing & Opening The Drawer")]
    [Range(0f, 1f)] public float Speed = 0.5f;

    [Header("Will Open The Drawer And Will Leave it Open Based On The Time Given & Will Close It")]
    [SerializeField] public bool OpenAndCloseDoor;
    [SerializeField] public float Timer;

    [Header("Manually Open & Close Drawers")]
    [SerializeField] public bool OpenDrawer;
    [SerializeField] public bool CloseDrawer;

    [Header("Object To Modify")]
    [SerializeField] GameObject DrawerObject;

    private void Start()
    {
        if (DrawerObject == null) {
            DrawerObject = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenAndCloseDoor)
        {
            OpenandClose();
        }
        else if (OpenDrawer)
        {
            OpeningDrawer();
        }
        else if (CloseDrawer) {
            ClosingDrawer();
        }
    }

    void OpeningDrawer() {
        if (currentdistance < MaxOpeningDistance)
        {
            DrawerObject.transform.localPosition = new Vector3(DrawerObject.transform.localPosition.x, DrawerObject.transform.localPosition.y, DrawerObject.transform.localPosition.z + (Speed * Time.deltaTime));
            currentdistance = currentdistance + (Speed * Time.deltaTime);
        }
        else
        {
            OpenDrawer = false;
        }
    }

    void ClosingDrawer()
    {
        if (currentdistance > 0)
        {
            DrawerObject.transform.localPosition = new Vector3(DrawerObject.transform.localPosition.x, DrawerObject.transform.localPosition.y, DrawerObject.transform.localPosition.z - (Speed * Time.deltaTime));
            currentdistance = currentdistance - (Speed * Time.deltaTime);
        }
        else
        {
            CloseDrawer = false;
            currentdistance = 0;
        }

    }

    float currentdistance = 0;
    bool ClosingDoor = false;
    public void OpenandClose()
    {
        if (!ClosingDoor)
        {
            if (currentdistance < MaxOpeningDistance)
            {
                DrawerObject.transform.localPosition = new Vector3(DrawerObject.transform.localPosition.x, DrawerObject.transform.localPosition.y, DrawerObject.transform.localPosition.z + (Speed * Time.deltaTime));
                currentdistance = currentdistance + (Speed * Time.deltaTime);
            }
            else
            {
                StartCoroutine(AutomaticCloseDrawer());
            }
        }

        if (ClosingDoor)
        {
            if (currentdistance > 0)
            {
                DrawerObject.transform.localPosition = new Vector3(DrawerObject.transform.localPosition.x, DrawerObject.transform.localPosition.y, DrawerObject.transform.localPosition.z - (Speed * Time.deltaTime));
                currentdistance = currentdistance - (Speed * Time.deltaTime);
            }
            else
            {
                ClosingDoor = false;
                OpenAndCloseDoor = false;
                currentdistance = 0;
            }
        }
    }

    IEnumerator AutomaticCloseDrawer()
    {
        yield return new WaitForSeconds(Timer);
        ClosingDoor = true;
        StopAllCoroutines();
    }
}
