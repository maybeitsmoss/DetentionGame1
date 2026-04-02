using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliddingDoorDrawersManager : MonoBehaviour
{

    [Header("Door Opening & Closing Speed\n")]
    [Range(0f, 100f)] public float DoorSpeedPercentage;

    [Header("Will Be The Distance To Be Used When Opening & Closing Doors\n(Will Be Flipped To Negative For Secondary Door)\n")]
    [SerializeField] public float DoorOpeningDistance;

    [Header("Open & Close Door Automatically, Closing Will Be Based On The Wait Time Provided\n")]
    [Range(0, 100)] public float DoorWaitTime;
    [SerializeField] public bool OpenClosePrimaryDoor;
    [SerializeField] public bool OpenCloseSecondaryDoor;

    [Header("Primary Door Controls\n")]
    [SerializeField] public bool OpenPrimaryDoor;
    [SerializeField] public bool ClosePrimaryDoor;

    [Header("Secondary Door Controls\n")]
    [SerializeField] public bool OpenSecondaryDoor;
    [SerializeField] public bool CloseSecondaryDoor;


    [Header("Door Objects\n")]
    [SerializeField] GameObject PrimaryDoor;
    [SerializeField] GameObject SecondaryDoor;


    float PrimaryDoorXAxis;
    float SecondaryDoorXAxis;

    // Update is called once per frame
    void Update()
    {
        PrimaryDoorXAxis = PrimaryDoor.transform.localPosition.x;
        SecondaryDoorXAxis = SecondaryDoor.transform.localPosition.x;
        if (OpenClosePrimaryDoor)
        {
            OpeningClosingPrimaryDoor();
        }
        else if (OpenCloseSecondaryDoor)
        {
            OpeningClosingSecondaryDoor();
        }
        else if (OpenPrimaryDoor)
        {
            OpeningPrimaryDoor();
        }
        else if (ClosePrimaryDoor)
        {
            ClosingPrimaryDoor();
        }
        else if (OpenSecondaryDoor)
        {
            OpeningSecondaryDoor();
        }
        else if (CloseSecondaryDoor) {
            ClosingSecondaryDoor();
        }
    }


    void OpeningPrimaryDoor() {
        if (PrimaryDoorXAxis > -DoorOpeningDistance)
        {
            PrimaryDoorXAxis = PrimaryDoorXAxis - (DoorSpeedPercentage * Time.deltaTime);
            PrimaryDoor.transform.localPosition = new Vector3(PrimaryDoorXAxis, PrimaryDoor.transform.localPosition.y, PrimaryDoor.transform.localPosition.z);
        }
        else {
            OpenPrimaryDoor = false;
        }
    }

    void ClosingPrimaryDoor()
    {
        if (PrimaryDoorXAxis < 0)
        {
            PrimaryDoorXAxis = PrimaryDoorXAxis + (DoorSpeedPercentage * Time.deltaTime);
            PrimaryDoor.transform.localPosition = new Vector3(PrimaryDoorXAxis, PrimaryDoor.transform.localPosition.y, PrimaryDoor.transform.localPosition.z);
        }
        else {
            ClosePrimaryDoor = false;
        }
    }

    void OpeningSecondaryDoor() {
        if (SecondaryDoorXAxis < DoorOpeningDistance)
        {
            SecondaryDoorXAxis = SecondaryDoorXAxis + (DoorSpeedPercentage * Time.deltaTime);
            SecondaryDoor.transform.localPosition = new Vector3(SecondaryDoorXAxis, SecondaryDoor.transform.localPosition.y, SecondaryDoor.transform.localPosition.z);
        }
        else {
            OpenSecondaryDoor = false;
        }
    }

    void ClosingSecondaryDoor()
    {
        if (SecondaryDoorXAxis > 0)
        {
            SecondaryDoorXAxis = SecondaryDoorXAxis - (DoorSpeedPercentage * Time.deltaTime);
            SecondaryDoor.transform.localPosition = new Vector3(SecondaryDoorXAxis, SecondaryDoor.transform.localPosition.y, SecondaryDoor.transform.localPosition.z);
        }
        else {
            CloseSecondaryDoor = false;
        }
    }

    //For Automatic Closing And Opening Doors
    bool automaticclosingdoor = false;
    void OpeningClosingPrimaryDoor() {

        if (!automaticclosingdoor)
        {
            if (SecondaryDoorXAxis > 0)
            {
                ClosingSecondaryDoor();
            }
            else
            {
                if (PrimaryDoorXAxis > -DoorOpeningDistance)
                {
                    OpeningPrimaryDoor();
                }
                else
                {
                    StartCoroutine(ClosingDoor());
                }
            }
        }
        else {
            if (PrimaryDoorXAxis < 0)
            {
                ClosingPrimaryDoor();
            }
            else
            {
                automaticclosingdoor = false;
                OpenClosePrimaryDoor = false;
            }
        }
    }

    void OpeningClosingSecondaryDoor() {
        if (!automaticclosingdoor)
        {
            if (PrimaryDoorXAxis < 0)
            {
                ClosingPrimaryDoor();
            }
            else
            {
                if (SecondaryDoorXAxis < DoorOpeningDistance)
                {
                    OpeningSecondaryDoor();
                }
                else
                {
                    StartCoroutine(ClosingDoor());
                }
            }
        }
        else
        {
            if (SecondaryDoorXAxis > 0)
            {
                ClosingSecondaryDoor();
            }
            else
            {
                automaticclosingdoor = false;
                OpenCloseSecondaryDoor = false;
            }
        }
    }

    IEnumerator ClosingDoor() {
        yield return new WaitForSeconds(DoorWaitTime);
        automaticclosingdoor = true;
        StopAllCoroutines();
    }
}
