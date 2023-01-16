using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void AddGameModeSelect()
    { 
        //TODO
        //Add some way for buttons to recognize what gamemode was selected
        //This method is currently on Host, Join and SinglePlayer buttons
    }

    public void SelectedCharacter()
    {
        //TODO
        //Add way for game to recognize what character was selected
        //perhaps ENUM?
    }

    public void ToggleUIElement(GameObject gameObject)
    {
        gameObject.SetActive(gameObject.activeInHierarchy);
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
