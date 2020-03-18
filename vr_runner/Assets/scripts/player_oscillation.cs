using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_oscillation : MonoBehaviour
{
    public float amplitude = 2f;
    public float frequency = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        oscillate();
    }

    public void oscillate()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Cos(transform.position.z * frequency) * amplitude, transform.localPosition.z);
    }
}
