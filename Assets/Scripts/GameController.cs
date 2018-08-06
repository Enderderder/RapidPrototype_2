using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Canvas pauseMenuCanvas;

    [System.NonSerialized] public bool isPaused = false;

    private CameraController playerCamController;

    private void Awake()
    {
        playerCamController = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CameraController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            isPaused = !isPaused;

        if (isPaused)
        {
            pauseMenuCanvas.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0.0f;
            playerCamController.enabled = false;
        }
        else
        {
            pauseMenuCanvas.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1.0f;
            playerCamController.enabled = true;
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
