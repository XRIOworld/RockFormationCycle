using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchAnimateParameter : MonoBehaviour
{
    public Animator objectToAnimate;
    public string animationParameterName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        objectToAnimate.SetTrigger(animationParameterName);
        Debug.Log(animationParameterName + "is Playing");
    }
}
