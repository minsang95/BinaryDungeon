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
                playerStat.CurrentStates.attackSO.delay -= 0.2f;
                if (playerStat.CurrentStates.attackSO.delay < 0.1f)
                    playerStat.CurrentStates.attackSO.delay = 0.1f;
            }
            if(gameObject.name == "ItemsPowerUp(Clone)")
            {
                playerStat.CurrentStates.attackSO.power += 1f;
            }
            if(gameObject.name == "ItemsSpeedUp(Clone)")
            {
                playerStat.CurrentStates.speed += 3f;
            }
            if(gameObject.name == "ItemsHPCure(Clone)")
            {
                playerHealth.ChangeHealth(10);
            }
            Destroy(gameObject);
        }
    }
}
