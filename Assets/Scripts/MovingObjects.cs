using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public int whatAmI;
    public float bulletSpeed = 10.0f;
    public float enemy1Speed = 3f;
    public float enemy2Speed = 4f;
    public float enemy3Speed = 4f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (whatAmI == 0)
        {
            //  bullet
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * bulletSpeed);
        }

        else if (whatAmI == 1) 
        {
            //  enemy1
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * enemy1Speed);
        }

        else if (whatAmI == 2)
        {
            // enemy2
            transform.Translate(new Vector3(-0.5f, -1, 0) * Time.deltaTime * enemy2Speed);
        }

        else if (whatAmI == 3)
        {
            //  enemy3
            transform.Translate(new Vector3(0.5f, -1, 0) * Time.deltaTime * enemy3Speed);
        }

        else if (whatAmI == 4)
        {
            //cloud
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * Random.Range(3f, 6f));
        }

        if ((transform.position.y > 10f || transform.position.y <= -10f) && whatAmI != 4)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y <= -10f && whatAmI == 4)
        {
            transform.position = new Vector3(Random.Range(-12f, 12f), 10f, 0);
        }
    }
}
