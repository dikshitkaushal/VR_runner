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
    public bool reachedfinishedline = false;
    private float timer = 0f;
    player_oscillation oscillate;
    public Camera fpcam;
    public float jumping_angle = 20.0f;
    public Canvas damage;
    private void Awake()
    {
        damage.enabled = false;
    }
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
        if(fpcam.transform.localEulerAngles.x >jumping_angle && isjumping==false && fpcam.transform.localEulerAngles.x < 90.0f)
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
        timer = 1.35f;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("obstacle"))
        {
            speed *= 0.3f;
            StartCoroutine(showdamage());
        }
       
        if(other.CompareTag("finishingline"))
        {
            reachedfinishedline = true;
        }
    }
    IEnumerator showdamage()
    {
        damage.enabled = true;
        yield return new WaitForSeconds(1f);
        damage.enabled = false;
    }
}
