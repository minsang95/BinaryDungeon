using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ObjectPool objectPool;
    public Transform Player { get; private set; }
    [SerializeField] private string playerTag = "Player";

    private void Awake()
    {
        Instance = this;
        objectPool = GetComponent<ObjectPool>();
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }
}
