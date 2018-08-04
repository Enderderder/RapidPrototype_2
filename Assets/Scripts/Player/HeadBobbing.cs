using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour {

    public float bobbingSpeed;
    public float bobbingAmount;
    public float midpoint;

    private float timer;
    private float waveSlice;
    private float translateChange;
    private float totalAxes;
    private Rigidbody rb;

    private void Awake()
    {
        rb = gameObject.GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        Bobbing();
    }

    void Bobbing()
    {
        waveSlice = 0.0f;
        translateChange = 0.0f;
        totalAxes = 0.0f;

        if (rb.velocity.x == 0 && rb.velocity.z == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveSlice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;

            if (timer > Mathf.PI * 2)
                timer = timer - (Mathf.PI * 2);
        }

        if (waveSlice != 0)
        {
            translateChange = waveSlice * bobbingAmount;
            totalAxes = rb.velocity.x + rb.velocity.z;
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            transform.localPosition.Set(0, midpoint + translateChange, 0);
        }
        else
        {
            transform.localPosition.Set(0, midpoint, 0);
        }
    }
}
