using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //  access lever: public or private
    //  type: int (5, 6, 7, etc.), float (2.4f, 5.4f, etc.)
    //  name: speed, plaerSpeed, ect. =/= Speed, PlayerSpeed
    //  optional: give initioal value
    public float speed = 8.0f;
    public int lives = 3;
    private int score;
    private float horizontalInput;
    private float verticalInput;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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
        if (transform.position.x >= 9.5f || transform.position.x <= -9.5f)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if (transform.position.y >= 1f)
        {
            transform.position = new Vector3(transform.position.x, 1f, 0);
        }
        else if (transform.position.y <= -4f)
        {
            transform.position = new Vector3(transform.position.x, -4f, 0);
        }
    }
    void Shooting()
    {
        //  if press spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  spawn bullet
            Instantiate(bullet, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
        
    }
}
