using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D itemBoxOpen)
    {
        if (itemBoxOpen.gameObject.tag == "ItemBox")
        {
            Destroy(itemBoxOpen.gameObject);
        }
    }
}
