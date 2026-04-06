using UnityEngine;

public class deskSFX : MonoBehaviour
{
    public AudioSource deskMoving;
    private Rigidbody rb;
    public float maxSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = rb.linearVelocity.magnitude;
        if (currentSpeed > 0.001f)
        {
            if (!deskMoving.isPlaying)
            {
                deskMoving.Play();
            }
            deskMoving.volume = Mathf.Clamp01(currentSpeed / maxSpeed);
        }
        else
        {
            deskMoving.Stop();
        }

    }
}
