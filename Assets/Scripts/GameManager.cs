using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject cloud;
    public GameObject coin;
    public GameObject powerUp;

    public TextMeshProUGUI scoreText;
    [SerializeField] private int score;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;

    private bool isPlayerAlive;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy1", 1f, 2f);
        InvokeRepeating("CreateEnemy2", 2f, 3f);
        InvokeRepeating("CreateEnemy3", 4f, 3f);
        StartCoroutine(SpawnCoin());
        InvokeRepeating("SpawnPowerUp", 6f, 9f);
        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;
        isPlayerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        Restart();
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

    IEnumerator SpawnCoin()
    {
        float xPos = Random.Range(-9.5f, 9.5f);
        float yPos = Random.Range(-4f, 1f);

        Instantiate(coin, new Vector3(xPos, yPos, 0), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        StartCoroutine(SpawnCoin());
    }

    void SpawnPowerUp()
    {
        float xPos = Random.Range(-9.5f, 9.5f);
        float yPos = Random.Range(-4f, 1f);

        Instantiate(powerUp, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    public void GameOver()
    {
        isPlayerAlive = false;
        CancelInvoke();
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
    }

    private void Restart()
    {
        if(Input.GetKeyDown(KeyCode.R) && isPlayerAlive == false)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
