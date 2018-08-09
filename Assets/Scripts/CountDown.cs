using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    public Text duedate;
    public int day;
    private float timeinsec = 60;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        duedate.text = "Due Date: " + day + "Day";

        timeinsec = timeinsec - Time.deltaTime;
        if (timeinsec <= 0)
        {
            day--;
            timeinsec = 60;
        }
	}
}
