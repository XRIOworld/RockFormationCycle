using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public void ToggleObject()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
        Debug.Log($"{gameObject.name} isActive:{gameObject.activeInHierarchy}");
    }

}
