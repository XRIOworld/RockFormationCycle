using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeInOnTrigger : MonoBehaviour
{
    public GameObject objectToFade; // The object to fade in and out
    public float fadeDuration = 1f; // The duration of the fade-in and fade-out effects

    private Renderer objectRenderer; // The renderer component of the object
    private Color originalColor; // The original color of the object
    private bool fadingIn = false; // Indicates whether the object is currently fading in
    private bool fadingOut = false; // Indicates whether the object is currently fading out

    private void Start()
    {
        objectRenderer = objectToFade.GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
        objectRenderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Set the object's alpha to 0
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Check if the entering object is the player
        {
            if (!fadingIn && !fadingOut) // Start fading in if not already fading
            {
                StartCoroutine(FadeIn()); // Start the fade-in effect
            }
            else if (fadingOut) // Stop fading out if already fading out
            {
                StopAllCoroutines(); // Stop any active coroutines
                fadingOut = false;
                StartCoroutine(FadeIn()); // Start the fade-in effect
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Check if the exiting object is the player
        {
            if (!fadingOut && !fadingIn) // Start fading out if not already fading
            {
                StartCoroutine(FadeOut()); // Start the fade-out effect
            }
            else if (fadingIn) // Stop fading in if already fading in
            {
                StopAllCoroutines(); // Stop any active coroutines
                fadingIn = false;
                StartCoroutine(FadeOut()); // Start the fade-out effect
            }
        }
    }

    private IEnumerator FadeIn()
    {
        fadingIn = true;
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, originalColor.a, elapsedTime / fadeDuration); // Calculate the new alpha value based on the elapsed time
            objectRenderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha); // Set the new alpha value of the object's color
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        objectRenderer.material.color = originalColor; // Set the object's color back to its original value
        fadingIn = false;
    }

    private IEnumerator FadeOut()
    {
        fadingOut = true;
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(originalColor.a, 0f, elapsedTime / fadeDuration); // Calculate the new alpha value based on the elapsed time
            objectRenderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha); // Set the new alpha value of the object's color
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        objectRenderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Set the object's alpha to 0
        fadingOut = false;
    }
}
