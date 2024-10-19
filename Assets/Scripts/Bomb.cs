using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    
    
    private PlayerController playerController;
    private float waitTime = 3.0f;
    private float timer = 0.0f;
    private float visualTime = 0.0f;
    
    public ParticleSystem explosionEffect;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameObject.transform.position =  new Vector3(playerController.transform.position.x, 0.9f, playerController.transform.position.z);
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {  
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            visualTime = timer;
            Destroy(gameObject);
            Instantiate(explosionEffect,transform.position,transform.rotation);
        }
        
        
    }
     
}
