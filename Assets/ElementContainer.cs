using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ElementContainer : MonoBehaviour
{
    [SerializeField] GameObject element;
    [SerializeField] Image spellQueue;
    DragDrop[] child;

    private void Start()
    {
        UpdateElement();
    }

    public void UpdateElement()
    {
        try
        {
            child = GetComponentsInChildren<DragDrop>();
        }catch { Debug.LogWarning("Contains No Child"); }

        if (child.Length == 0)
        {
            var instance = Instantiate(element, gameObject.transform);
            instance.transform.SetSiblingIndex(0);
            instance.GetComponent<DragDrop>().spellQueue = spellQueue;
        }
        else if(GetComponentsInChildren<DragDrop>().Length > 1) 
        {
            Destroy(child[0].gameObject);
        }
    }
}
