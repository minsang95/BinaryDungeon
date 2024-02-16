using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	private RoomTemplates templates;
    private int rand;
	public bool spawned = false;

    public float waitTime = 0.5f;

	void Start(){
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

    }


	void Spawn(){
		if(spawned == false){
            rand = Random.Range(1, templates.TopBottomRooms.Length);
            //방 갯수 재한
            if (templates.rooms.Count == 7)
			{
                Instantiate(templates.TopBottomRooms[0], transform.position, templates.TopBottomRooms[0].transform.rotation);
                Destroy(gameObject, waitTime);
            }
			else
			{
                Instantiate(templates.TopBottomRooms[rand], transform.position, templates.TopBottomRooms[rand].transform.rotation);
                Destroy(gameObject, waitTime);
            }
        } 
		spawned = true;
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Spawn();

        }
    }


}
