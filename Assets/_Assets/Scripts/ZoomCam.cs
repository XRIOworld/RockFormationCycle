using UnityEngine;
using System.Collections;

public class ZoomCam : MonoBehaviour
{
    public bool zooming;
    public float zoomSpeed;
    public new Camera camera;


    void Update()
    {
        if (zooming)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            float zoomDistance = zoomSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            camera.transform.Translate(ray.direction * zoomDistance, Space.World);
        }
    }
}