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

    public bool openReady = true;

    private void OnCollisionEnter2D(Collision2D itemBoxOpen)
    {
        if (itemBoxOpen.gameObject.tag == "ItemBox")
        {
            if(openReady)
            {
                itemAnim = itemBoxOpen.gameObject.GetComponent<Animator>();
                itemAnim.SetBool("ItemBoxOpen", true);

                Destroy(itemBoxOpen.gameObject, 1.0f);

                Debug.Log(itemBoxOpen.transform.position);
                ItemRandomSpawn(itemBoxOpen.transform.position);
                StartCoroutine(OpenDelay());
            }
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
        }
        else if (randomNumber == 1)
        {
            Instantiate(powerSpeedUp, position, spawnRotation);
        }
        else if (randomNumber == 2)
        {
            Instantiate(speedUp, position, spawnRotation);
        }
        else
        {
            Instantiate(hpCure, position, spawnRotation);
        }
    }

    IEnumerator OpenDelay()
    {
        openReady = false;
        yield return new WaitForSeconds(1f);
        openReady = true;
    }
}
