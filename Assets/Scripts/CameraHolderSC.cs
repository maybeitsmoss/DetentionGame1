using UnityEngine;

public class CameraHolderSC : MonoBehaviour
{

    public Transform cameraPosition;


    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
