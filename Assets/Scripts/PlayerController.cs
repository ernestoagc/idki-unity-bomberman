using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
        public float speed = 4.0f;

        private Animator playerAnim;

        public float horizontalInput;
        public float forwardInput;
        private GameManager gameManager;

        public Bomb bombPrefab;
        
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameManager.isGameOver)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
            if (Input.anyKey)
            {
                playerAnim.SetFloat("Speed_f", 0.5f);
                playerAnim.SetBool("Static_b",true);
            }
            else
            {
                playerAnim.SetFloat("Speed_f", 0f);
            }
            

            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Rotate(Vector3.up , 200f * horizontalInput * Time.deltaTime);
                
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bombPrefab);
            }
        }

       

    }

    private void Walking()
    {
    }

    void OnParticleCollision(GameObject other)
    { 
        if (other.gameObject.CompareTag("Explosion"))
        {
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",2);
            gameManager.GameOver(false);
        }
    }


    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
