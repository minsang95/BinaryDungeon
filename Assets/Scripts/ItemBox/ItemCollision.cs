using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    public Animator itemAnim;

    private void OnCollisionEnter2D(Collision2D itemBoxOpen)
    {
        if (itemBoxOpen.gameObject.tag == "ItemBox")
        {
            itemAnim = itemBoxOpen.gameObject.GetComponent<Animator>();
            
            itemAnim.SetBool("ItemBoxOpen", true);
            Destroy(itemBoxOpen.gameObject, 1.0f);
        }
    }

}
