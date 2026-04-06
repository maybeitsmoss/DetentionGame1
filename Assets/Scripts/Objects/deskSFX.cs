using UnityEngine;

public class deskSFX : MonoBehaviour
{
    public AudioSource deskMoving;
    private Rigidbody rb;
    public float maxSpeed = 1f;

    //Vector3 lastPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = rb.linearVelocity.magnitude;
        if (currentSpeed > 0.1f)
        {
            if (!deskMoving.isPlaying)
            {
                deskMoving.Play();
                //Debug.Log(rb.linearVelocity.magnitude);
            }
            deskMoving.volume = Mathf.Clamp01(currentSpeed / maxSpeed);
        }
        else
        {
        deskMoving.Stop();
        }
    }
}
