using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnTouchAnimate : MonoBehaviour
{
    public Animator objectToAnimate;
    public string animationName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        objectToAnimate.Play(animationName);
        Debug.Log(animationName + "is Playing");

    }

}
