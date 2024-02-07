using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public void PlayGame()
    {
        Application.LoadLevel("TestMap");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionsPanel()
    {
        optionsPanel.SetActive(true);
    }

    public void Quit()
    {
        optionsPanel.SetActive(false);
    }
}
