using UnityEngine;

public class BossMucus : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 1.5f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<Rigidbody2D>().drag = 0f;
    }
}
