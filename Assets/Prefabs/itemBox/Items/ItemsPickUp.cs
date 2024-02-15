using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPickUp : MonoBehaviour
{
    CharacterStatsHandler playerStat;
    HealthSystem playerHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStat = collision.GetComponent<CharacterStatsHandler>();
            playerHealth = collision.GetComponent<HealthSystem>();
            if(gameObject.name == "ItemsPowerSpeedUp(Clone)")
            {
                playerStat.CurrentStates.attackSO.delay -= 0.05f;
            }
            if(gameObject.name == "ItemsPowerUp(Clone)")
            {
                playerStat.CurrentStates.attackSO.power += 5f;
            }
            if(gameObject.name == "ItemsSpeedUp(Clone)")
            {
                playerStat.CurrentStates.speed += 10f;
            }
            if(gameObject.name == "ItemsHPCure(Clone)")
            {
                playerHealth.ChangeHealth(2);
            }
            Destroy(gameObject);
        }
    }
}
