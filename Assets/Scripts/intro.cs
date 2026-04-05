using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public AudioSource crash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        text1.enabled = false;
        text2.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Start()
    {
        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        yield return new WaitForSeconds(1f);

        text1.enabled = true;
        crash.Play();

        //play audio
        //display text
        yield return new WaitForSeconds(3f);

        text2.enabled = true;
        crash.Play();
        //fade out text

        yield return new WaitForSeconds(3f);

        StartCoroutine(FadeOutText());
    }

    IEnumerator FadeOutText()
    {
        float fadeDuration = 1f; // Duration of the fade-out effect
        float elapsedTime = 0f;

        Color text1Color = text1.color;
        Color text2Color = text2.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            text1.color = new Color(text1Color.r, text1Color.g, text1Color.b, alpha);
            text2.color = new Color(text2Color.r, text2Color.g, text2Color.b, alpha);

            yield return null;
        }

        // Ensure the text is fully transparent at the end of the fade-out
        text1.enabled = false;
        text2.enabled = false;
        SceneManager.LoadScene("MAINSCENE");
    }
}
