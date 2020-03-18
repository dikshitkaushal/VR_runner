using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gamecontroller : MonoBehaviour
{
    public player_movement player;
    public TextMesh infotext;
    private float gametimer = 0f;
    private float restarttimer = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
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
