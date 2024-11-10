using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //  access layer: public or private
    //  type: int (5, 6, 7, etc.), float (2.4f, 5.4f, etc.)
    //  name: speed, playerSpeed, ect. =/= Speed, PlayerSpeed
    //  optional: give initioal value
    private float horizontalInput;
    private float verticalInput;
    public float horizontalScreenSize = 9.5f;
    public float verticalScreenSize = 4f;
    
    public float speed = 8.0f;
    public int lives = 3;

    public GameObject bullet;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().updateLives(lives);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        //  if (condition) {do this}
        //  else if (other condition) {do this}
        //  else {do this final}
        if (transform.position.x >= horizontalScreenSize || transform.position.x <= -horizontalScreenSize)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if (transform.position.y >= verticalScreenSize/verticalScreenSize)
        {
            transform.position = new Vector3(transform.position.x, verticalScreenSize/verticalScreenSize, 0);
        }

        else if (transform.position.y <= -verticalScreenSize)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenSize, 0);
        }
    }
    void Shooting()
    {
        //  if press spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  spawn bullet
            Instantiate(bullet, transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
            //  play gunshot sound
            
        }
        
    }

    public void LoseALife()
    {
        lives--;
        if (lives == 0)
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        GameObject.Find("GameManager").GetComponent<GameManager>().updateLives(lives);
    }
}
