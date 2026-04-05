using UnityEngine;

public class tvSFX : MonoBehaviour
{
    public AudioSource tvBreak;
    private bool hasFallen = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor" && hasFallen == false)
        {
            tvBreak.Play();
            hasFallen = true;
        }
        
    }
}
