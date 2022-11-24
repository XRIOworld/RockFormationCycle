using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchAnimateParticle : MonoBehaviour
{
    Animator objectToAnimate;
    public GameObject particleEffect;

    // Start is called before the first frame update
    void Start()
    {
        objectToAnimate = GetComponentInChildren<Animator>();
        particleEffect.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            objectToAnimate.SetTrigger("float");
            particleEffect.SetActive(true);
            particleEffect.transform.position = collider.transform.position;
            Invoke("DeactiveParticles", 2f);
        }
    }

    void DeactiveParticles()
    {
        particleEffect.SetActive(false);
    }

}
