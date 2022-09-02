using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnTouchScaleFixed : MonoBehaviour
{
    public GameObject objectToScale;
    public float scaleAmount;
    private Vector3 currentScale;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnMouseDown()
    {
        currentScale = objectToScale.transform.localScale;
        objectToScale.transform.localScale = currentScale * scaleAmount;
    }
}
