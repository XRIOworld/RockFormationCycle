using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClickRotateFixed : MonoBehaviour
{
    public float rotationAmount;
    private Quaternion currentRotation; // stores a value for rotation

    // Start is called before the first frame update
    void Start()
    {
    }
    public void RotateObjectLeft()
    {
        currentRotation = transform.rotation;
        transform.rotation = currentRotation * Quaternion.Euler(0, rotationAmount, 0); // updates the y rotation of the object
    }

    public void RotateObjectRight()
    {
        currentRotation = transform.rotation;
        transform.rotation = currentRotation * Quaternion.Euler(0, -rotationAmount, 0); // updates the y rotation of the object
    }
}
