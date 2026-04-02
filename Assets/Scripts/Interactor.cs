using UnityEngine;
using System.Collections;
using System.Collections.Generic;

interface IInteractable
{
    public void Interact();
    public void Drop();

    public void Open();
}

public class Interactor : MonoBehaviour
{
    private bool canPick = true;
    private IInteractable lastInteractObj = null;

    public Transform InteractorSource;
    public float InteractRange;
    public GameObject hand;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
    }
}
