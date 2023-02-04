using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreButtons : MonoBehaviour
{
    public void ToggleGameobject(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
