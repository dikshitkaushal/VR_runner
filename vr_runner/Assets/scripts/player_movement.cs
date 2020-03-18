using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed = 0f;
    public float acceleration = 0.3f;
    public float max_speed = 7f;
    public float jumpingforce = 350f;
    public bool isjumping=false;
    private float timer = 0f;
    player_oscillation oscillate;

    // Start is called before the first frame update
    void Start()
    {
        oscillate = GetComponentInChildren<player_oscillation>();
    }

    // Update is called once per frame
    void Update()
    {
        speed += acceleration * Time.deltaTime;
        if (speed > max_speed)
        {
            speed = max_speed;
        }
        timer -= Time.deltaTime;
        transform.position += speed * Vector3.forward * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && isjumping==false)
        {
            jump();
        }
        if(timer<0)
        {
            isjumping = false;
            oscillate.enabled = true;
        }
    }

    public void jump()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpingforce);
        isjumping = true;
        oscillate.enabled = false;
        timer = 1.5f;
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
    }
}
