using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gamecontroller : MonoBehaviour
{
    public player_movement player;
    public AudioClip[] clips;
    private AudioSource source;
    AudioSource crowdvoice;
    public TextMesh infotext;
    private float gametimer = 0f;
    private float restarttimer = 3f;
    private void Awake()
    {
        player.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        crowdvoice = GameObject.Find("Player").GetComponent<AudioSource>();
        source = GetComponent<AudioSource>();
        start_the_race();
    }

    public void start_the_race()
    {
        crowdvoice.volume = 0.28f;
        playaudio(0);
        StartCoroutine(set());
    }
    IEnumerator set()
    {
        yield return new WaitForSeconds(1f);
        playaudio(1);
        StartCoroutine(gunshot());
    }
    IEnumerator gunshot()
    {
        yield return new WaitForSeconds(1.8f);
        playaudio(2);
        crowdvoice.volume = 0.6f;
        player.enabled = true;
    }
    public void playaudio(int clip)
    {
        source.clip = clips[clip];
        source.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (!player.reachedfinishedline)
        {
            gametimer += Time.deltaTime;
            infotext.text = "Avoid the Obstacles!\nClick the Button to jump! \nYour Time : " + Mathf.Floor(gametimer);
        }
        else
        { 
            restarttimer -= Time.deltaTime;
            infotext.text = "You Win!\nYour Time : " + Mathf.Floor(gametimer)+"\nrestarting game " + Mathf.Floor(restarttimer);
            
            if(restarttimer<1)
            {
                restartgame();
            }
        }
    }

    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
