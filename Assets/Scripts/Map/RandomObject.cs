using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{

    private RoomTemplates templates;
    public GameObject[] Monsters;
    public GameObject[] Objects;

    private int randMon;
    private int ranObj;
    private float x = 0;
    private float y = 10f;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }
    public void MakeObject()
    {
       
        for (int i = 0; i < 4; i++)
        {
            if(Monsters.Length == 1)
            {
                transform.position = new Vector3(0, (templates.rooms.Count * 10f)- 7.5f, 0);
                randMon = Random.Range(0, Monsters.Length);
                Instantiate(Monsters[randMon], transform.position, transform.rotation);
                GameManager.Instance.ActiveBossUI();
                break;

            } else
            {
                x = Random.Range(-7.0f, 7.0f);
                y = Random.Range((templates.rooms.Count * 10f) - 12.5f, (templates.rooms.Count * 10f) - 6.5f);
                transform.position = new Vector3(x, y, 0);
                randMon = Random.Range(0, Monsters.Length);
                Instantiate(Monsters[randMon], transform.position, transform.rotation);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (Monsters.Length == 1)
            {
                break;
            }
            else
            {
                x = Random.Range(-7.0f, 7.0f);
                y = Random.Range((templates.rooms.Count * 10f) - 10f, (templates.rooms.Count * 10f) - 4f);
                transform.position = new Vector3(x, y, 0);
                ranObj = Random.Range(0, Objects.Length);
                Instantiate(Objects[ranObj], transform.position, transform.rotation);
            }
        }

    }
 }
