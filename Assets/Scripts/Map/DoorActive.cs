using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActive : MonoBehaviour
{
    private RoomTemplates templates;

    public GameObject OpenDoor;
    public GameObject CloseDoor;
    public GameObject BossDoor;

    // Start is called before the first frame update
    void Start()
    {

        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        if (GameObject.Find("Monster"))
        {
            OpenDoor.SetActive(true);
            CloseDoor.SetActive(false);
            BossDoor.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Monster").Length != 0 || GameObject.FindGameObjectsWithTag("Boss").Length != 0)
        {
            CloseDoor.SetActive(true);
        }
        else
        {
            CloseDoor.SetActive(false);
            if (templates.rooms.Count == 8)
            {
                if (!GameManager.Instance.bossRoomOpen)
                {
                    BossDoor.SetActive(true);
                }
                else
                {
                    BossDoor.SetActive(false);
                }
            }
        }
    }
}
