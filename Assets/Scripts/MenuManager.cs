using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Canvas menuCanvas;
    public Canvas howToPlayCanvas;
    public Canvas quitGameCanvas;

    private void Awake()
    {
        menuCanvas.enabled = true;
        howToPlayCanvas.enabled = false;
        quitGameCanvas.enabled = false;
    }

    private void Update()
    {
        if (howToPlayCanvas.enabled && Input.GetButtonDown("Cancel"))
            Button_HowToPlay_Back();

        if (quitGameCanvas.enabled && Input.GetButtonDown("Cancel"))
            quitGameCanvas.enabled = false;
    }

    public void Button_Menu_Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Button_Menu_HowToPlay()
    {
        menuCanvas.enabled = false;
        howToPlayCanvas.enabled = true;
    }

    public void Button_Menu_Quit()
    {
        quitGameCanvas.enabled = true;
    }

    public void Button_HowToPlay_Back()
    {
        menuCanvas.enabled = true;
        howToPlayCanvas.enabled = false;
    }

    public void Button_Quit_Yes()
    {
        Application.Quit();
    }

    public void Button_Quit_No()
    {
        quitGameCanvas.enabled = false;
    }
}
