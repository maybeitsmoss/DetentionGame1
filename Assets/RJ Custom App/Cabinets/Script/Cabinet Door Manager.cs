using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetDoorManager : MonoBehaviour
{
    public enum OpeningAngle
    {
        Left,
        Right
    }

    [Header("Set Opening Angle If Door Is Left Or Right\n")]
    public OpeningAngle DoorOpeningAngle;

    [Header("Door Opening & Closing Speed\n")]
    [Range(0f, 100f)] public float DoorSpeedPercentage;

    [Header("Open Doors & Automatically Close It\nBased On The Set Amount Of Wait Time Provided\n")]
    [SerializeField] public bool OpenAndCloseDoor;
    [Range(0, 100)] public float DoorWaitTime;

    [Header("Manually Closing & Opening Doors\n")]
    [SerializeField] public bool OpenDoorOnly;
    [SerializeField] public bool CloseDoorOnly;

    [Header("Door Objects\n")]
    [SerializeField] GameObject Door;

    bool CloseDoor = false;
    float angle = 0f;
    float DoorangleX;
    float DoorangleY;
    float DoorangleZ;

    private void Start()
    {
        //Will Make Door Object This if Game Object Is Null
        if (Door == null) {
            Door = this.gameObject;
        }
    }

    void Update()
    {
        DoorangleX = Door.transform.localEulerAngles.x;
        DoorangleY = Door.transform.localEulerAngles.y;
        DoorangleZ = Door.transform.localEulerAngles.z;
        if (OpenAndCloseDoor) {
            OpenCloseDoor();
        }
        else if (OpenDoorOnly)
        {
            OpenOnly();
        }
        else if (CloseDoorOnly)
        {
            CloseOnly();
        }
    }

    
    void OpenCloseDoor() {
        if (!CloseDoor)
        {
            if (DoorOpeningAngle == OpeningAngle.Left)
            {
                if (DoorangleY <= 90f)
                {
                    Door.transform.localEulerAngles = new Vector3(DoorangleX, DoorangleY + (DoorSpeedPercentage * Time.deltaTime), DoorangleZ);
                }
                else
                {
                    StartCoroutine(DoorClosingTimer());
                }
            }
            else if (DoorOpeningAngle == OpeningAngle.Right)
            {
                if (angle <= 90f) {
                    angle = angle + (DoorSpeedPercentage * Time.deltaTime);
                    Door.transform.localEulerAngles = new Vector3(DoorangleX, DoorangleY - (DoorSpeedPercentage * Time.deltaTime), DoorangleZ);
                }
                else{
                    StartCoroutine(DoorClosingTimer());
                }
            }
        }

        if (CloseDoor)
        {
            if (DoorOpeningAngle == OpeningAngle.Left)
            {
                if (DoorangleY >= 1f)
                {
                    Door.transform.localEulerAngles = new Vector3(DoorangleX, DoorangleY - (DoorSpeedPercentage * Time.deltaTime), DoorangleZ);
                }
                else
                {
                    Door.transform.localEulerAngles = new Vector3(DoorangleX, 0f, DoorangleZ);
                    CloseDoor = false;
                    OpenAndCloseDoor = false;
                }
            }
            else if (DoorOpeningAngle == OpeningAngle.Right)
            {
                if (angle >= 1f)
                {
                    angle = angle - (DoorSpeedPercentage * Time.deltaTime);
                    Door.transform.localEulerAngles = new Vector3(DoorangleX, DoorangleY + (DoorSpeedPercentage * Time.deltaTime), DoorangleZ);
                }
                else
                {
                    angle = 0f;
                    Door.transform.localEulerAngles = new Vector3(DoorangleX, 0f, DoorangleZ);
                    CloseDoor = false;
                    OpenAndCloseDoor = false;
                }
            }
        }
    }

    void OpenOnly()
    {
            if (angle <= 90f)
            {
            angle = angle + (DoorSpeedPercentage * Time.deltaTime);
            if (DoorOpeningAngle == OpeningAngle.Left)
                {
                    Door.transform.localEulerAngles = new Vector3(DoorangleX, DoorangleY + (DoorSpeedPercentage * Time.deltaTime), DoorangleZ);
                }
                else if (DoorOpeningAngle == OpeningAngle.Right)
                {
                Door.transform.localEulerAngles = new Vector3(DoorangleX, DoorangleY - (DoorSpeedPercentage * Time.deltaTime), DoorangleZ);
                }
            }else
            {
                OpenDoorOnly = false;
            }
    }

    void CloseOnly()
    {
        if (angle >= 1f){
            angle = angle - (DoorSpeedPercentage * Time.deltaTime);
            if (DoorOpeningAngle == OpeningAngle.Left)
            {
                Door.transform.localEulerAngles = new Vector3(DoorangleX, DoorangleY - (DoorSpeedPercentage * Time.deltaTime), DoorangleZ);
            }
            else if (DoorOpeningAngle == OpeningAngle.Right)
            {
                Door.transform.localEulerAngles = new Vector3(DoorangleX, DoorangleY + (DoorSpeedPercentage * Time.deltaTime), DoorangleZ);
            }
        }
        else
        {
            angle = 0f;
            Door.transform.localEulerAngles = new Vector3(DoorangleX, 0f, DoorangleZ);
            CloseDoorOnly = false;
        }
    }


    IEnumerator DoorClosingTimer()
    {
        yield return new WaitForSeconds(DoorWaitTime);
        CloseDoor = true;
        StopAllCoroutines();
    }
}
