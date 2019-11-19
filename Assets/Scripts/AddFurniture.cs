using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFurniture : MonoBehaviour
{
    public GameObject desk;
    public GameObject bed;
    public GameObject chair;
    public GameObject sofa;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    public void addDesk()
    {
        Instantiate(desk, player.transform.position + Vector3.forward, Quaternion.identity);
        desk.AddComponent<objScript>();
    }

    public void addBed()
    {
        Instantiate(bed, player.transform.position + Vector3.forward, Quaternion.identity);
        bed.AddComponent<objScript>();
    }

    public void addChair()
    {
        Instantiate(chair, player.transform.position + Vector3.forward, Quaternion.identity);
        chair.AddComponent<objScript>();
    }

    public void addSofa()
    {
        Instantiate(sofa, player.transform.position + Vector3.forward, Quaternion.identity);
        sofa.AddComponent<objScript>();
    }

    void Update()
    {
        
    }
}
