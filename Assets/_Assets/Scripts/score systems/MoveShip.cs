using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float JS_up = Input.GetAxis("JS_up") * Time.deltaTime * speed;
        
        transform.Translate(horizontal, JS_up, vertical);
    }




}
