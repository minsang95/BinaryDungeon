using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyItem : MonoBehaviour
{
    private string keyTag;
    Image keySprite;

    private void Awake()
    {
        keyTag = gameObject.tag;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (keyTag)
            {
                case "KeyZero":
                    GameManager.Instance.keyZeroCount++;
                    for(int i = 0; i < GameManager.Instance.keyZeroCount; i++)
                    {
                        if (i < 3)
                        {
                            keySprite = GameManager.Instance.KeyZero[i].GetComponent<Image>();
                            keySprite.color = Color.white;
                        }
                    }
                    break;
                case "KeyOne":
                    GameManager.Instance.keyOneCount++;
                    for (int i = 0; i < GameManager.Instance.keyOneCount; i++)
                    {
                        if (i < 7)
                        {
                            keySprite = GameManager.Instance.KeyOne[i].GetComponent<Image>();
                            keySprite.color = Color.white;
                        }
                    }
                    break;
                case "KeyPlus":
                    GameManager.Instance.keyPlusCount++;
                    for (int i = 0; i < GameManager.Instance.keyPlusCount; i++)
                    {
                        if (i < 2)
                        {
                            keySprite = GameManager.Instance.KeyPlus[i].GetComponent<Image>();
                            keySprite.color = Color.white;
                        }
                    }
                    break;
                case "KeyEqual":
                    GameManager.Instance.keyEqualCount++;
                    for (int i = 0; i < GameManager.Instance.keyEqualCount; i++)
                    {
                        if (i < 1)
                        {
                            keySprite = GameManager.Instance.KeyEqual[i].GetComponent<Image>();
                            keySprite.color = Color.white;
                        }
                    }
                    break;
            }
            Destroy(gameObject);
        }
    }
}
