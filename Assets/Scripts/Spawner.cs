using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    // Singleton
    public static Spawner Instance { get; set; }

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
        return (GameObject)Instantiate(Resources.Load(itemName, typeof(GameObject)),
            SpawnPoint_Desk.transform);
    }
}
