using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemBox;

    public void ItemGridPosition()
    {
        float itemPosX = Random.Range(-8.0f, 8.0f);
        float itmePosY = Random.Range(-4.5f, 3.5f);
        transform.position = new Vector3(itemPosX, itmePosY, 0);
        Debug.Log("Ãâ·ÂµÊ");

        /*for (int i = 0; i < 2; i++)
        {
            Vector3 ramdonPos = new Vector3 ()
        }*/
    }


    void Start()
    {
        ItemGridPosition();
    }


    void Update()
    {
        
    }
}
