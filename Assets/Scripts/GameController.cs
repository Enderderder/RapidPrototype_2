using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Canvas pauseMenuCanvas;

    [System.NonSerialized] public bool isPaused = false;

    private void Update()
    {
        if (isPaused)
        {
            pauseMenuCanvas.enabled = true;
        }
        else
        {
            pauseMenuCanvas.enabled = false;
        }
    }

    public void Button_PauseMenu_Resume()
    {
        isPaused = false;
    }

    public void Button_PauseMenu_Quit()
    {
        SceneManager.LoadScene(0);
    }
}
