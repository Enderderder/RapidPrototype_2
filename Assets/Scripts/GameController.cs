using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Singleton Instance
    public static GameController instance;

    public int Score { get; set; }



    [System.NonSerialized] public bool isPaused = false;

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
        DontDestroyOnLoad(this.gameObject);
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
