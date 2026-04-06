using UnityEngine;

public class RollingSFX : MonoBehaviour
{
    public AudioSource rollingSound;
    private Rigidbody rb;
    public float maxSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float currentSpeed = rb.linearVelocity.magnitude;
        if (currentSpeed > 0.1f)
        {
            if (!rollingSound.isPlaying)
            {
                rollingSound.Play();
                Debug.Log(rb.linearVelocity.magnitude);
            }
            rollingSound.volume = Mathf.Clamp01(currentSpeed / maxSpeed);
        }
        else
        {
            rollingSound.Stop();
        }    
    }
}
