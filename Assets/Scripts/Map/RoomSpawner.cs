using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	private RoomTemplates templates;
	private int rand;
	public bool spawned = false;

    public float waitTime = 0.4f;

	void Start(){
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.05f);
	}


	void Spawn(){
		if(spawned == false){
			if(openingDirection == 1)
            {
                rand = Random.Range(1, templates.BottomRooms.Length);
                if (templates.BottomNum.Count >= 2)
				{
                    Instantiate(templates.BottomRooms[0], transform.position, templates.BottomRooms[0].transform.rotation);
                }
				else
				{
                    Instantiate(templates.BottomRooms[rand], transform.position, templates.BottomRooms[rand].transform.rotation);
                }
				templates.BottomNum.Add(1);
            } else if(openingDirection == 2)
            {
                rand = Random.Range(0, templates.TopRooms.Length);
				if (templates.TopNum.Count >= 3)
                {
                    Instantiate(templates.TopRooms[0], transform.position, templates.TopRooms[0].transform.rotation);
                }
				else
				{
					Instantiate(templates.TopRooms[rand], transform.position, templates.TopRooms[rand].transform.rotation);
				}
				templates.TopNum.Add(2);
            } 
			spawned = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log(other.gameObject.tag);
        Debug.Log(other.tag);
        Debug.Log(other.CompareTag("Map"));
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
		}
	}
}
