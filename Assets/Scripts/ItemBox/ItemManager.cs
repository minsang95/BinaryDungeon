using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemManager : MonoBehaviour
{
    public GameObject itemBox;
    public int randomNumber;
    public GameObject powerUp;
    public GameObject powerSpeedUp;
    public GameObject speedUp;
    public GameObject hpCure;


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

    private void OnCollisionEnter2D(Collision2D itemBox)
    {
            if (itemBox.gameObject.tag == "Player")
            {
                /*Instantiate(ItemRandomSpawn);*/
                ItemRandomSpawn();
                Debug.Log(itemBox.transform.position);
            }
    }


    private void ItemRandomSpawn()
    {
        randomNumber = Random.Range(0, 3);

        if (randomNumber == 0)
        {
            Instantiate(powerUp);
        }
        else if (randomNumber == 1)
        {
            Instantiate(powerSpeedUp);
        }
        else if (randomNumber == 2)
        {
            Instantiate(speedUp);
        }
        else
        {
            Instantiate(hpCure);
        }
    }



    void Start()
    {
        ItemGridPosition();
    }


    void Update()
    {

    }
}
