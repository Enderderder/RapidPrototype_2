using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyNote : MonoBehaviour {
    public GameObject closingnode;
    public KeyCode key;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		closingnode.transform.localScale = new Vector3(closingnode.transform.localScale.x - 0.02f, closingnode.transform.localScale.y - 0.02f, closingnode.transform.localScale.z - 0.02f);
        if (Input.GetKeyDown(key))
        {
            Destroy(this.gameObject);
        }

        if (closingnode.transform.localScale.y <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
