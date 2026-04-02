using UnityEngine;

public class InteractableObj : MonoBehaviour, IInteractable
{
    //private bool canPick = true;
    [SerializeField] GameObject target;
    public float throwforce = 5f;
    


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
        //canPick = true;
        this.GetComponent<Rigidbody>().AddForce(transform.forward * throwforce, ForceMode.Impulse);
    }
}
