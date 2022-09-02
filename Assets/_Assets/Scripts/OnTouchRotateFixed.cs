using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnTouchRotateFixed : MonoBehaviour
{
    public GameObject objectToRotate;
    public float rotationAmount;
    private Quaternion currentRotation; // stores a value for rotation

    // Start is called before the first frame update
    void Start()
    {   
    }

    public void OnMouseDown()
    {
        currentRotation = objectToRotate.transform.rotation;
        objectToRotate.transform.rotation = currentRotation * Quaternion.Euler(0, rotationAmount, 0); // updates the y rotation of the object
    }
}
