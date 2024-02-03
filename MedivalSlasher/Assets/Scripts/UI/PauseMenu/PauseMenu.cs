using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private bool IsInPause;

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
    }

    public void ClosePause()
    {
        IsInPause = false;
    }
}
