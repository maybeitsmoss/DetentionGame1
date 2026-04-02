using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*interface IInteractable
{
    public void Interact();
    public void Drop();

    public void Open();
}*/

public class Interactor : MonoBehaviour
{
    private bool canPick = true;
    //private IInteractable lastInteractObj = null;

    public Transform InteractorSource;
    public float InteractRange;
    public GameObject hand;

    public GameObject lastObjectPicked;

    private UnlockableObjects currentKeyType;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentKeyType = UnlockableObjects.none;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canPick == true)
            {
                if(Physics.Raycast(InteractorSource.position, InteractorSource.forward, out RaycastHit hitInfo, InteractRange))
                {
                    if(hitInfo.collider.gameObject.tag == "key" && hitInfo.collider.gameObject != null)
                    {
                        if (hitInfo.collider.gameObject.GetComponent<keyObj>() != null)
                        {
                            hitInfo.collider.gameObject.GetComponent<keyObj>().Interact();
                            
                            
                            lastObjectPicked = hitInfo.collider.gameObject;
                            currentKeyType = lastObjectPicked.GetComponent<keyObj>().keyType;

                            canPick = false;
                        }
                    }
                }
                
                

            }

            else if (canPick == false)
            {
                if (Physics.Raycast(InteractorSource.position, InteractorSource.forward, out RaycastHit hitInfo, InteractRange))
                {
                    if (hitInfo.collider.gameObject.tag == "lock" && hitInfo.collider.gameObject != null)
                    {
                        var keyTypeNeeded = hitInfo.collider.gameObject.GetComponent<database>().objectType;
                        if (keyTypeNeeded == currentKeyType)
                        {
                            Debug.Log("open");

                            hitInfo.collider.gameObject.SendMessage("OnUnlock");
                            //hitInfo.collider.gameObject.GetComponent<database>().OnUnlockEvent.Invoke();

                            Destroy(hand.transform.GetChild(0).gameObject);
                            canPick = true;
                            lastObjectPicked = null;
                            currentKeyType = UnlockableObjects.none;
                        }
                        else
                        {
                            //incorrect!!
                            Debug.Log("mismatch");
                        }


                        
                    }
                }
                else
                {
                    if (lastObjectPicked != null)
                    {
                        lastObjectPicked.GetComponent<keyObj>().Drop();
                        lastObjectPicked = null;
                        currentKeyType = UnlockableObjects.none;
                        canPick = true;
                    }
                }
                
                
            }
        }
    }


    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canPick == true)
            {
                Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
                if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj) && hitInfo.collider.gameObject.tag == "key")
                    {
                        interactObj.Interact();
                        lastInteractObj = interactObj;
                        canPick = false;
                    }
                }
                
            }
            else if (canPick == false)
            {
                Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
                if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
                {
                    if (hitInfo.collider.gameObject.tag == "lock")
                    {
                        Debug.Log("open");
                        Destroy(hand.transform.GetChild(0).gameObject);
                        canPick = true;
                    }
                }




                else if (lastInteractObj != null)
                {
                    lastInteractObj.Drop();
                    lastInteractObj = null;
                }
                canPick = true;
            }
        }
    }*/
}
