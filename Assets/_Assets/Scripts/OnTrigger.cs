using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    Animator animator;
    public GameObject planeParticle;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        planeParticle.SetActive(false);
       
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "box")
        {
            animator.SetTrigger("crateJump");
            planeParticle.SetActive(true);
            planeParticle.transform.position = collider.transform.position;
            Invoke("DeactiveParticles", 2f);
        }


    }


    void DeactiveParticles()
    {
        planeParticle.SetActive(false);
    }

}
