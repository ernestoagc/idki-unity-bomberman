using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DetectCollision : MonoBehaviour
{
    private PlayerController playerController;
    private GameManager gameManager;
    public ParticleSystem particleEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       Debug.Log("====> "+other.gameObject.name);


       if (other.gameObject.name == "Player")
       {
       }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Gem") && collision.gameObject.CompareTag("Player"))
        { 
            Destroy(gameObject);
            Instantiate(particleEffect,transform.position,transform.rotation);
            gameManager.GameOver(true);
        }
    }
    
    void OnParticleCollision(GameObject other)
    {
        if (gameObject.CompareTag("Box"))
        {
            Destroy(gameObject);
        } 
        else if (gameObject.CompareTag("Gem") && other.gameObject.CompareTag("Player"))
        {
          //  Destroy(gameObject);
        }

       
    }
}
