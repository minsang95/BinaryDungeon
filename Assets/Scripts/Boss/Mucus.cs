using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BossMucus : MonoBehaviour
{
    private CharacterStatsHandler playerStat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerStat = collision.GetComponent<CharacterStatsHandler>();
            playerStat.CurrentStates.speed += 0.5f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStat = collision.GetComponent<CharacterStatsHandler>();
            playerStat.CurrentStates.speed -= 0.5f;
        }
    }
}
