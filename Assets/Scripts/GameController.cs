using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Singleton Instance
    public static GameController instance;

    public Canvas pauseMenuCanvas;

    [System.NonSerialized] public bool isPaused = false;
    public int Score { get; set; }

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
    private void Start()
    {
        Score = 0;
    }







    public void AddScore(int _value)
    {
        Score += _value;
    }
}
