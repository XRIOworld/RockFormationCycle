using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    Animator animator;
    public GameObject particleEffect;
    public GameObject objectToRotate;
    public float rotationAmount;
    private Quaternion currentRotation; // stores a value for rotation


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        particleEffect.SetActive(false);
       
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "box")
        {
            animator.SetTrigger("crateJump");
            currentRotation = objectToRotate.transform.rotation;
            objectToRotate.transform.rotation = currentRotation * Quaternion.Euler(0, rotationAmount, 0); // updates the y rotation of the object
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
