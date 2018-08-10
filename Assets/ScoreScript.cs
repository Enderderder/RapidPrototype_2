using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Text score;
    public Spawner gamecontroller;

    private void Start()
    {
        gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Spawner>();
    }

    private void Update()
    {
        score.text = "Score: " + gamecontroller.Score.ToString();
        Cursor.lockState = CursorLockMode.None;
    }

    public void Button_Menu()
    {
        SceneManager.LoadScene(0);
    }
}
