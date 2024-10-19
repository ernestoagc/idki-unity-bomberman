using System.Collections;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public ParticleSystem winEffect;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    

    public void UserWinScreen()
    {
        gameObject.SetActive(true);
        StartCoroutine(SpawnEfects());
    }

    public void UserLoseScreen()
    {
        gameObject.SetActive(true);
    }

    IEnumerator SpawnEfects()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Instantiate(winEffect, GenerateSpawn(Random.Range(-23, 23), Random.Range(-23, 23)), transform.rotation);
        }
    }

    private Vector3 GenerateSpawn(int posX, int posZ)
    {
        Vector3 randomPos = new Vector3(posX, 0, posZ);
        return randomPos;
    }
}
