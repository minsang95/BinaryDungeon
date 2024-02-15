using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    Animator itemAnim;

    public GameObject powerUp;
    public GameObject powerSpeedUp;
    public GameObject speedUp;
    public GameObject hpCure;

    private void OnCollisionEnter2D(Collision2D itemBoxOpen)
    {
        if (itemBoxOpen.gameObject.tag == "ItemBox")
        {
            itemAnim = itemBoxOpen.gameObject.GetComponent<Animator>();
            itemAnim.SetBool("ItemBoxOpen", true);

            Destroy(itemBoxOpen.gameObject, 1.0f);

            Debug.Log(itemBoxOpen.transform.position);
            ItemRandomSpawn(itemBoxOpen.transform.position);
        }
    }

    private void ItemRandomSpawn(Vector3 position)
    {
        position += new Vector3(-0.5f, 1.2f);
        int randomNumber = Random.Range(0, 4);
        Quaternion spawnRotation = Quaternion.identity;

        if (randomNumber == 0)
        {
            Instantiate(powerUp, position, spawnRotation);
            Destroy(powerUp, 1.0f);
        }
        else if (randomNumber == 1)
        {
            Instantiate(powerSpeedUp, position, spawnRotation);
            Destroy(powerSpeedUp, 1.0f);
        }
        else if (randomNumber == 2)
        {
            Instantiate(speedUp, position, spawnRotation);
            Destroy(speedUp, 1.0f);
        }
        else
        {
            Instantiate(hpCure, position, spawnRotation);
            Destroy(hpCure, 1.0f);
        }
    }

}
