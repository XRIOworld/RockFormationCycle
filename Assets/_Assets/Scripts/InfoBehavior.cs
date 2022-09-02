
using UnityEngine;

public class InfoBehavior : MonoBehaviour
{
    const float SPEED = 6f;
    [SerializeField]

    //that's what I going to scale up
    Transform SectionInfo;

    //what I going to interpolate. default the info panel to 0 so it's off at start
    //Vector3 desiredScale = Vector3.one;
    Vector3 desiredScale = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        SectionInfo.localScale = Vector3.Lerp(SectionInfo.localScale, desiredScale, Time.deltaTime * SPEED);
    }

    public void OpenInfo()
    {
        desiredScale = Vector3.one;
    }

    public void CloseInfo()
    {
        desiredScale = Vector3.zero;
    }
}
