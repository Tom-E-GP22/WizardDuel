using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpellQueue : MonoBehaviour
{
    [SerializeField] private GameObject duelButton;
    private bool[] queue = new bool[5];
    bool containsFalse = false;

    public void addToQueue(int slot)
    {
        queue[slot] = true;
        containsFalse = false;

        foreach (bool b in queue)
        {
            if (!b)
            {
                containsFalse = true;
                break;
            }
        }

        if (!containsFalse)
            duelButton.SetActive(true);
    }

    //TEMP
    //change to element enum and nullchecking
}
