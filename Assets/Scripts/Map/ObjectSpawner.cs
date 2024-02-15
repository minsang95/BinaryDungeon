using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private RoomTemplates templates;
    public GameObject objs;
    public float waitTime = 0.5f;


    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

    }
    void ObjectSpawn()
    {
            objs.GetComponent<RandomObject>().MakeObject();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ObjectSpawn();
            Destroy(gameObject);

        }
    }

}
