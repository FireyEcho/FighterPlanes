using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy1", 1f, 2f);
        InvokeRepeating("CreateEnemy2", 2f, 3f);
        InvokeRepeating("CreateEnemy3", 4f, 3f);
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
}
