using UnityEngine;

public class TrashSFX : MonoBehaviour
{
    public AudioSource trashSound;
    private bool hasFallen = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor" && hasFallen == false)
        {
            trashSound.Play();
            hasFallen = true;
        }
        
    }
}
