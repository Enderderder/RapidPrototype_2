using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyNote : MonoBehaviour {
    public GameObject closingnode;
    public KeyCode key;
    private float maxsize;
    Image m_graphic;
    // Use this for initialization
    void Start () {
        maxsize = closingnode.transform.localScale.y;
        m_graphic = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update () {
		closingnode.transform.localScale = new Vector3(closingnode.transform.localScale.x - 0.02f, closingnode.transform.localScale.y - 0.02f, closingnode.transform.localScale.z - 0.02f);
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
            Destroy(this.gameObject);
        }

        if (closingnode.transform.localScale.y <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
