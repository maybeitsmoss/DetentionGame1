using UnityEngine;

public class basketball : MonoBehaviour
{
    public AudioSource bounceSound;

    public Timer timer;
    private Rigidbody rb;
    public float maxSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        if (bounceSound.isPlaying == false && timer.timeRemaining <= 55)
        {
            float currentSpeed = rb.linearVelocity.magnitude;
            float volumeVel = Mathf.Clamp01(currentSpeed / maxSpeed);
            bounceSound.volume = volumeVel;
            bounceSound.Play();
        }
    }
}
