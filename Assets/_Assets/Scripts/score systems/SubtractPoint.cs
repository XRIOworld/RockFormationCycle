using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractPoint : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        ScoringSystem.theScore -= 10;
        Destroy(gameObject);
    }
}
