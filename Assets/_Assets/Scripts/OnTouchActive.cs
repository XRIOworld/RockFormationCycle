using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchActive : MonoBehaviour
{
    public GameObject objectToActivate;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    public void OnMouseDown()
    {
        objectToActivate.SetActive(true);

    }
}
