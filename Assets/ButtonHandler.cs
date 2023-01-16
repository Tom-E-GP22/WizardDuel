using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public void AddGameModeSelect()
    { 
        //TODO
        //Add some way for buttons to recognize what gamemode was selected
        //This method is currently on Host, Join and SinglePlayer buttons
    }

    public void ToggleUIElement(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void DisableButton(Button button)
    {
        button.interactable = false;
    }

    public void DebugButton()
    {
        Debug.Log("Button Pressed");
    }
}
