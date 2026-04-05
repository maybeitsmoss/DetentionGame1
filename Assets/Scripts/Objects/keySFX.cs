using UnityEngine;

public class keySFX : MonoBehaviour
{

    public AudioSource keyDrop;
    public AudioSource keyPickup;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            GetComponent<AudioSource>().Play();
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hand")
        {
            keyPickup.Play();
        }
    }
}
