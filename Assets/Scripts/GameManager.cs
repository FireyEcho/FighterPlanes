using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject cloud;
    public GameObject coin;

    public TextMeshProUGUI scoreText;
    [SerializeField] private int score;

    public TextMeshProUGUI livesText;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy1", 1f, 2f);
        InvokeRepeating("CreateEnemy2", 2f, 3f);
        InvokeRepeating("CreateEnemy3", 4f, 3f);
        InvokeRepeating("SpawnCoin", Random.Range(1f, 5f), Random.Range(5f, 6f));
        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemy1()
    {
        Instantiate(enemy1, new Vector3(Random.Range(-6, 6), 9, 0), Quaternion.identity);
    }

    void CreateEnemy2()
    {
        Instantiate(enemy2, new Vector3(Random.Range(0, 8), 9, 0), Quaternion.identity);
    }

    void CreateEnemy3()
    {
        Instantiate(enemy3, new Vector3(Random.Range(0, -8), 9, 0), Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int newScore)
    {
        score = score + newScore;
        scoreText.text = "Score: " + score;
    }

    public void updateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    void SpawnCoin()
    {
        float xPos = Random.Range(-9.5f, 9.5f);
        float yPos = Random.Range(-4f, 1f);

        Instantiate(coin, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }
}
