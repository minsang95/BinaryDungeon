using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public TextMeshProUGUI currentHpText;
    public TextMeshProUGUI maxHpText;


    private RoomTemplates templates;
    public GameObject BossUI;

    private void Awake()
    {
        Instance = this;
        objectPool = GetComponent<ObjectPool>();
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;

        healthSystem = Player.GetComponent<HealthSystem>();

        healthSystem.OnDamage += UpdateHealthUI;
        healthSystem.OnDeath += GameOver;

        gameObject.SetActive(false);
    }

    private void Update()
    {
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        hpSlider.value = healthSystem.CurrentHealth / healthSystem.MaxHealth;
    }
    
    private void GameOver()
    {
        gameOverUI.SetActive(true);
    }


    public void ActiveBossUI()
    {
        BossUI.SetActive(true);
    }

    public void Retry()
    {
        Debug.Log("다시하기");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
