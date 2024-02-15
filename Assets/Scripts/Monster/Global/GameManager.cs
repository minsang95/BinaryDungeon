using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ObjectPool objectPool;
    public Transform Player { get; private set; }
    [SerializeField] private string playerTag = "Player";

    [SerializeField] private Slider hpSlider;
    [SerializeField] private GameObject gameOverUI;

    private HealthSystem healthSystem;
    private CharacterStatsHandler characterStatsHandler;
    private BossHead bossHead;
    

    private void Awake()
    {
        Instance = this;
        objectPool = GetComponent<ObjectPool>();
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;

        healthSystem = Player.GetComponent<HealthSystem>();
        characterStatsHandler = Player.GetComponent<CharacterStatsHandler>();

        //healthSystem.OnDamage += UpdateHealthUI;
        healthSystem.OnDeath += GameOver;

        gameObject.SetActive(false);
    }

    private void Update()
    {
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        hpSlider.value = characterStatsHandler.CurrentStates.maxHealth / healthSystem.MaxHealth;
    }
    
    private void GameOver()
    {
        gameOverUI.SetActive(true);
    }
}
