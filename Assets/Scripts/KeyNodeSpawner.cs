using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyNodeSpawner : MonoBehaviour {
    public GameObject[] keynotes;
    private int randnum;
	// Use this for initialization
	void OnEnable() {
            StartCoroutine("Loadkeynote");
    }
	
    IEnumerator Loadkeynote()
    {
        while (true)
        {
            randnum = Random.Range(0, keynotes.Length);
            if (GameObject.Find(keynotes[randnum].name) == null)
            {
                GameObject keynode = Instantiate(keynotes[randnum], this.transform) as GameObject;
                keynode.name = keynotes[randnum].name;
            }

            yield return new WaitForSeconds(1);
        }
    }
}
