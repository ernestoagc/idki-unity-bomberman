using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    
    public List<GameObject> obstacles;
    public GameObject player;
    public Transform obstaclesParent;
    public bool isGameOver=false;
    public GameObject gem;
    public GameObject mapObstacles;
    public bool userWon;
    public WinManager winManager;
    public LoseManager loseManager;
    public GameObject restartButton;
    
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        // winManager = GameObject.Find("WinManager").GetComponent<WinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private Vector3 GenerateSpawn(int posX, int posZ)
    {
        Vector3 randomPos = new Vector3(posX, 0, posZ);
        return randomPos;
    }

    private void BuildObstacles()
    {
        List<Vector3> boxPositions = new List<Vector3>();
        for (int i = -23; i < 23; i += 3)
        {
            for (int z = -23; z < 23; z += 3)
            {
                if (Random.Range(0f, 1f) > 0.5f)
                {
                    i = (i == -2) ? 5 : i;
                    z = (z == -2) ? 5 : z;
                    
                    
                    int index = Random.Range(0, obstacles.Count);
                    Vector3 positionObstacle = GenerateSpawn(i, z);
                    
                    Instantiate(obstacles[index],positionObstacle,transform.rotation,obstaclesParent);
                    if (obstacles[index].CompareTag("Box"))
                    {
                        boxPositions.Add(positionObstacle);
                    }
                }

            }
        }
        
        //drawing Gem
        Instantiate(gem,boxPositions[Random.Range(0,boxPositions.Count)],transform.rotation);
        
    }


    private void DrawPlayer(GameObject player)
    {
        int x = Random.Range(-23, 23);
        int z = Random.Range(-23, 23);

        if ((x < -2 || x > 2) && (z < -2 || z > 2))
        {
            if (Random.Range(0f, 1f) > 0.5f)
            {
                x = Random.Range(-2, 2);
            }
            else
            {
                z = Random.Range(-2, 2);
            }
        }

        player.gameObject.transform.position = GenerateSpawn(x, z);

    }

    public void StartGame()
    {
        isGameOver = false;
        BuildObstacles();
        DrawPlayer(player);
        player.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver(bool hasWin)
    {
        userWon = hasWin;
        restartButton.SetActive(true);
        mapObstacles.SetActive(false);
        if (hasWin)
        {
            winManager.UserWinScreen();
        }
        else
        { 
            loseManager.UserLoseScreen();
        }
    }
}
