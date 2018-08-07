using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyNodeSpawner : MonoBehaviour {
    public GameObject[] keynotes;
    private int randnum;
	// Use this for initialization
	void OnEnable() {
            StartCoroutine("loadkeynote");
    }
	
    IEnumerator loadkeynote()
    {
        while (true)
        {
            randnum = Random.Range(0, keynotes.Length);
            if (GameObject.Find(keynotes[randnum].name) == null)
            {
                GameObject keynode = Instantiate(keynotes[randnum]) as GameObject;
                keynode.name = keynotes[randnum].name;
                keynode.transform.parent = this.transform;
            }

            yield return new WaitForSeconds(1);
        }
    }

	// Update is called once per frame
	void Update () {
		

       
    }
}
