using System.Collections;
using UnityEngine;

public class BossMucus : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(RemoveMucus());
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<Rigidbody2D>().drag = 0f;
    }
    IEnumerator RemoveMucus()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
