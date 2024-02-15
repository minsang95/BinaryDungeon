using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActive : MonoBehaviour
{

    public GameObject OpenDoor;
    public GameObject CloseDoor;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Monster"))
        {
            OpenDoor.SetActive(true);
            CloseDoor.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Monster").Length != 0 || GameObject.FindGameObjectsWithTag("Boss").Length != 0)
        {
            CloseDoor.SetActive(true);
        } else
        {
            CloseDoor.SetActive(false);

        }

    }
}
