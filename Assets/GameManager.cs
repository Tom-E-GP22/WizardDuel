using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public enum Characters
    {
        Ghost,
        Robe,
        Sam,
        Trigger
    }

    [HideInInspector]
    public Characters selectedCharacter;

    private bool gameMode_CPU = false;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SelectCharacter(int characterIndex)
    {
        selectedCharacter = (Characters)characterIndex;
    }
}
