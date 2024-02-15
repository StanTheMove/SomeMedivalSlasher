using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject OptionsPanel;
    public GameObject BackButton;
    private bool IsInPause;
    private bool OptionsButton;
    private bool ButtonBack;


    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsInPause = !IsInPause;
        }

        if (!IsInPause)
        {
            PausePanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }

        if (IsInPause)
        {
            PausePanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
        }

        if (OptionsButton)
        {
            OptionsPanel.SetActive(true);
            PausePanel.SetActive(false);          
        }

        if (ButtonBack)
        {
            OptionsPanel.SetActive(false);
            PausePanel.SetActive(true);
        }
    }

    public void ClosePause()
    {
        IsInPause = false;
    }

    public void ButtonOptions()
    {
        OptionsButton = true;
    }

    public void bakButton()
    {
        ButtonBack = true;
    }
}
