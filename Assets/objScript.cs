using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objScript : MonoBehaviour
{
    GameObject player;
    bool Sel = false;
    Color temp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        temp = GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Sel)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                transform.Rotate(0, 90, 0);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.Rotate(0,-90,0);
            }
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f)) 
        {
            if (Input.GetMouseButton(0) && Sel)
            {
                if (hit.collider.gameObject.tag == "Plane")
                {
                    transform.position = hit.point + Vector3.up *(transform.localScale.y - hit.transform.localScale.y); 
                }
                else
                {
                    transform.position = hit.point;
                }
            }
            else
            {
                return;
            }
        }
    }
    
    private void OnMouseDown()
    {
        Sel = true;
        GetComponent<MeshRenderer>().material.color = Color.red;
        GetComponent<MeshCollider>().enabled = false;
    }
    private void OnMouseUp()
    {
        Sel = false;
        GetComponent<MeshRenderer>().material.color = temp;
        GetComponent<MeshCollider>().enabled = true;
    }
}
