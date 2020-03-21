using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_the_game : MonoBehaviour
{
    public GameObject play;
    public Camera fpcam;
    public gamecontroller controller;
    public Canvas canvas;
    private void Awake()
    {
        canvas.enabled = false;
        controller.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpcam.transform.position,fpcam.transform.forward,out hit))
        {
            if(hit.transform.CompareTag("play"))
            {
                controller.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}
