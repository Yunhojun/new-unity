using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float rspeed = 100f;

    GameObject cam;
    GameObject subC;

    Rigidbody rigid;

    bool Q;
    float rx;
    float ry;
    float h;
    float v;
    float wheel;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero + Vector3.up;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        subC = GameObject.FindGameObjectWithTag("UpCam");
        cam.transform.position = transform.position + Vector3.up * 1;
        rx = 0;
        ry = 0;
        wheel = 0;
    }

    private void FixedUpdate()
    {
        if (cam.GetComponent<Camera>().enabled)
        {
            if (Input.GetMouseButton(1))
            {
                rotate();
            }
            if (Input.GetMouseButton(2)||(Q&&Input.GetMouseButton(0)))
            {
                move(-h,-v);
            }
            move(wheel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Q = !Q;
        }
        h = Input.GetAxisRaw("Mouse X");
        v = Input.GetAxisRaw("Mouse Y");

        if (Input.GetMouseButton(1))
        {
            rx += Input.GetAxis("Mouse X") * rspeed * Time.deltaTime;
            ry = Mathf.Clamp(ry, -90, 90);
            ry += Input.GetAxis("Mouse Y") * rspeed * Time.deltaTime;            
        }

        wheel = Input.GetAxis("Mouse ScrollWheel");
    }
        
    private void move(float h, float v)
    {
        Vector3 dir = new Vector3(h, v, 0);      
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        subC.transform.position = transform.position + Vector3.up * 100;
    }

    private void rotate()
    {            
        transform.rotation = Quaternion.Euler(-ry, rx, 0);
    }

    private void move(float wheel)
    {
        Vector3 dir = new Vector3(0, 0, wheel) * speed * 30 * Time.deltaTime;
        transform.Translate(dir);
        subC.transform.position = transform.position + Vector3.up * 100;
    }
}
