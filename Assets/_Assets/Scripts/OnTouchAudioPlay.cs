using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchAudioPlay : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnMouseDown()
    {
        audioSource.Play();
    }
}
