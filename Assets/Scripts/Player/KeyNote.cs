using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyNote : MonoBehaviour {
    public GameObject closingnode;
    public KeyCode key;
    private float maxsize;
    Image m_graphic;

    private GameObject slider;
    private GameObject text;
    public Slider progessbar;
    private Text percentage;
    // Use this for initialization
    void Start () {
        maxsize = closingnode.transform.localScale.y;
        m_graphic = GetComponent<Image>();
        slider = GameObject.Find("MainSlider");
        progessbar = slider.GetComponent<Slider>();
        text = GameObject.Find("mainpercentage");
        percentage = text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
		closingnode.transform.localScale = new Vector3(closingnode.transform.localScale.x - 1 * Time.deltaTime, closingnode.transform.localScale.y - 1 * Time.deltaTime, closingnode.transform.localScale.z - 1 * Time.deltaTime);
        if(closingnode.transform.localScale.y < maxsize/2 && closingnode.transform.localScale.y > maxsize / 4)
        {
            m_graphic.color = Color.yellow;
        }
        else if(closingnode.transform.localScale.y < maxsize / 4)
        {
            m_graphic.color = Color.red;
        }
        if (Input.GetKeyDown(key))
        {
            progessbar.value += 0.05f;
            int progess = (int)((progessbar.value) * 100);
            percentage.text = progess + "%";
            Destroy(this.gameObject);
        }
        else if (Input.anyKeyDown)
        {
            progessbar.value -= 0.02f;
            int progess = (int)((progessbar.value) * 100);
            percentage.text = progess + "%";
        }




        if (closingnode.transform.localScale.y <= 0)
        {
            progessbar.value -= 0.02f;
            int progess = (int)((progessbar.value) * 100);
            percentage.text = progess + "%";
            Destroy(this.gameObject);
        }
    }
}
