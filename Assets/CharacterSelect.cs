using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public enum Character { Ghost, Robe, Sam, Trigger}
    static Character selectedCharacter;
    public Character thisCharacter;

    public void SelectCharacter(bool selected)
    {
        var outline = GetComponents<Outline>()[1];
        if (selected)
        {
            outline.effectColor = new Color(1, 0.7f, 0);
        }
        else
            outline.effectColor = Color.white;

        selectedCharacter = thisCharacter;
        Debug.Log("pressed " + selectedCharacter);

        //TODO
        //Add way for game to recognize what character was selected
        //perhaps ENUM?
    }
}
