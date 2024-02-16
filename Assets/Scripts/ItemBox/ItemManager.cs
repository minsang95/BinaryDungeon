using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemManager : MonoBehaviour
{
    public GameObject itemBox;

    public void ItemGridPosition()
    {
        for (int i = 0; i < 3; i++)
        {
            Invoke("ItemBoxCreate", 0.0f);
            float itemPosX = Random.Range(-7.0f, 7.0f);
            float itmePosY = Random.Range(-2.5f, 2.5f);
            transform.position = new Vector3(itemPosX, itmePosY, 0);

            if (i >= 3)
            {
                break;
            }
        }
    }

    private void ItemBoxCreate()
    {
        if (itemBox != null)
        {
            Instantiate(itemBox);
        }
    }

    private void OnCollisionEnter2D(Collision2D player)
    {
    }



    void Start()
    {
        ItemGridPosition();
    }


    void Update()
    {

    }
}
