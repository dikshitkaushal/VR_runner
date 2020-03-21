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
    public Camera fpcam;
    AudioSource crowdvoice;
    public TextMesh infotext;
    private float gametimer = 0f;
    public GameObject rematch;
    public GameObject rockets;
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
        rematch.SetActive(false);
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
            infotext.text = "Avoid the Obstacles!\nMove the Head Down to jump! \nYour Time : " + Mathf.Floor(gametimer);
        }
        else
        {
            
            RaycastHit hit;
            if (Physics.Raycast(fpcam.transform.position, fpcam.transform.forward, out hit))
            {
                if (hit.transform.CompareTag("restart"))
                {
                    restartgame();
                }
            }
            infotext.text = "You Win!\nYour Time : " + Mathf.Floor(gametimer);
            rematch.SetActive(true);
            rockets.SetActive(true);
            StartCoroutine(stopgame());
        }
    }
    IEnumerator stopgame()
    {
        yield return new WaitForSeconds(1);
        playaudio(3);
        player.enabled = false;
    }

    public void restartgame()
    {
        rockets.SetActive(false);
        player.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
