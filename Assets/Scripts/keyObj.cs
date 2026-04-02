using UnityEngine;

public class keyObj : MonoBehaviour
{
    public UnlockableObjects keyType;

    public GameObject target;

    public void Interact()
    {
        transform.position = target.transform.position;
        this.transform.parent = target.transform;
        this.transform.localEulerAngles = new Vector3(0, 0, 0);
        this.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Drop()
    {
        this.transform.parent = null;
        this.GetComponent<Rigidbody>().isKinematic = false;
    }


}

public enum UnlockableObjects
{
    door, drawer1, drawer2, drawer3, drawer4, teachercabinet, supplycabinet, janitorcabinet, laptop, window, vent, toolbox, none
}