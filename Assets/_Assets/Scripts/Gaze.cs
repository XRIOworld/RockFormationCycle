using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    [SerializeField]List<InfoBehavior> infos = new List<InfoBehavior>();

    void Start()
    {
        UpdateInfoBehaviorList();
    }

    public void UpdateInfoBehaviorList()
    {
        infos.Clear();
        infos = FindObjectsOfType<InfoBehavior>().ToList();
    }

    void Update()
    {
        if (Physics.Raycast(transform.position,transform.forward, out RaycastHit hit)){
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("hasInfo"))
            {
                //print("HERE");
                UpdateInfoBehaviorList();
                OpenInfo(go.GetComponent<InfoBehavior>());
            }
            

            
        }
    }

    void OpenInfo(InfoBehavior desiredInfo)
    {
        foreach (InfoBehavior info in infos)
        {
            if (info == desiredInfo)
            {
                //print("found desired info");
                info.OpenInfo();
            } 
            
            else
            {
                info.CloseInfo();
            }
        }
    }

    void CloseAll()
    {
        foreach (InfoBehavior info in infos)
        {
            info.CloseInfo();
        }
    }

}
