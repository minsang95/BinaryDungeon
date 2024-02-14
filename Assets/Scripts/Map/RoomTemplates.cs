using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] BottomRooms;
	public GameObject[] TopRooms;

    public GameObject closedRoom;

	public List<GameObject> rooms;
    public List<int> BottomNum;
    public List<int> TopNum;

    public float waitTime = 10;
	private bool spawnedBoss;
	public GameObject boss;

	void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false){
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-1)
                {
                    Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
                    spawnedBoss = true;
					deleteDestory();

                }
			}
		} else {
			waitTime -= Time.deltaTime;
		}
	}

    void deleteDestory()
    {
		GameObject[] array = GameObject.FindGameObjectsWithTag("Destroy");
		foreach(GameObject gameObject in array)
        {
            Destroy(gameObject);
        }
    }
}
