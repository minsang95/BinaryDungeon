using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemBox;

    public void ItemGridPosition()
    {
        for (int i = 0;i < 2; i++)
        {
            InvokeRepeating("itemBoxCreate", 0.0f, 0.0f);

            for (int j = 0; j < 2; j++)
            {
                float itemPosX = Random.Range(-8.0f, 8.0f);
                float itmePosY = Random.Range(-4.5f, 3.5f);
                transform.position = new Vector3(itemPosX, itmePosY, 0);
                Debug.Log("Ãâ·ÂµÊ");
            }

            if (i >= 3)
            {
                break;
            }
        }
    }

    private void itemBoxCreate()
    {
        Instantiate(itemBox);
    }


    void Start()
    {
        ItemGridPosition();
    }


    void Update()
    {

    }
}
