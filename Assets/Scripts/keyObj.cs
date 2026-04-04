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

        this.GetComponent<Collider>().enabled = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
        //this.GetComponent<Rigidbody>().SetActive(false);
    }

    public void Drop()
    {
        this.transform.parent = null;
        this.GetComponent<Collider>().enabled = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
        //this.GetComponent<Rigidbody>().SetActive(true);
    }


}

public enum UnlockableObjects
{
    door, drawer1, drawer2, drawer3, drawer4, teachercabinet, supplycabinet, supplycabinet2, janitorcabinet, laptop, window, vent, toolbox, none
}