using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCamScript : MonoBehaviour
{
    GameObject subc;
    float h, v, y;
    [SerializeField]
    float speed = 5f;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        transform.position = Player.transform.position + Vector3.up * 100;
    }

    private void FixedUpdate()
    {
        if(GetComponent<Camera>().enabled == true)
        {
            print(123);
            move();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            h = 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            h = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            h = -1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            h = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            v = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            v = -1;
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            v = 0;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            y = 1;
        }
        if (Input.GetKeyUp(KeyCode.Space)||Input.GetKeyUp(KeyCode.LeftShift))
        {
            y = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            y = -1;
        }
    }

    void move()
    {
        Vector3 dir = new Vector3(h, v, -y);
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }
}
