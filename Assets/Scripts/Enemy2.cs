using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float enemySpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-0.5f, -1, 0) * Time.deltaTime * enemySpeed);

        if (transform.position.y < -4)
        {
            Destroy(this.gameObject);
        }
    }
}
