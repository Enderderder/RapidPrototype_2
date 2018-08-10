using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    // Singleton
    public static Spawner Instance { get; set; }

    public float Score { get; set; }

    // Variables
    private GameObject SpawnPoint_Desk;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            Score = GameObject.Find("GameController").GetComponent<GameController>().Score;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        // Find the desk spawn position so we can spawn item on to it
        SpawnPoint_Desk = GameObject.FindGameObjectWithTag("DeskSpawnPoint");
    }

    public GameObject SpawnItemOnDesk(string itemName)
    {
        string itemPath = "Prefabs/Items/" + itemName;

        return (GameObject)Instantiate(Resources.Load(itemPath, typeof(GameObject)),
            SpawnPoint_Desk.transform);
    }
}
