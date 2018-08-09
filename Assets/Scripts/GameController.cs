using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Singleton Instance
    public static GameController instance;

    public int Score { get; set; }

    public Canvas pauseMenuCanvas;
    [System.NonSerialized] public bool isPaused = false;
    private CameraController playerCamController;
    private PlayerController playerController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        //DontDestroyOnLoad(this.gameObject);

        pauseMenuCanvas.enabled = false;
        playerCamController = GameObject.FindGameObjectWithTag("Player").GetComponent<CameraController>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
        Score = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && GameObject.Find("computer screen") == null)
            isPaused = !isPaused;

        if (isPaused)
        {
            pauseMenuCanvas.enabled = true;
            Time.timeScale = 0;
            playerCamController.enabled = false;
            playerController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            pauseMenuCanvas.enabled = false;
            Time.timeScale = 1;
            playerCamController.enabled = true;
            playerController.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void AddScore(int _value)
    {
        Score += _value;
    }

    public void Button_Pause_Resume()
    {
        isPaused = false;
    }

    public void Button_Pause_Quit()
    {
        SceneManager.LoadScene(0);
    }
}
