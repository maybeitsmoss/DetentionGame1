using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float timeRemaining;

    public bool timerStart = false;

    public AudioSource footsteps;
    //public AudioSource doorOpen;
    public bool isPlayingFootsteps = false;
    public AudioSource countdown;
    public bool isPlayingCountdown = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Update()
    {
        if (timerStart == true)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (timeRemaining <= 10 && isPlayingCountdown == false)
        {
            countdown.Play();
            isPlayingCountdown = true;
        }
        if(timeRemaining <= 4 && !isPlayingFootsteps)
        {
            footsteps.Play();
            isPlayingFootsteps = true;
        }
        if (timeRemaining <= 0)
        {
            timerText.text = "00:00";
            footsteps.Stop();
            countdown.Stop();
            //doorOpen.Play();
        }
        
    }
}
