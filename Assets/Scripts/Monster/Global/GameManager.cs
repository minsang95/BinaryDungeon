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
    [SerializeField] private GameObject gameClearUI; // 게임 클리어 UI 추가

    private HealthSystem healthSystem;

    public TextMeshProUGUI currentHpText;
    public TextMeshProUGUI maxHpText;

    private RoomTemplates templates;
    public GameObject BossUI;

    public GameObject[] KeyZero;
    public GameObject[] KeyOne;
    public GameObject[] KeyPlus;
    public GameObject[] KeyEqual;
    [HideInInspector] public int keyZeroCount = 0;
    [HideInInspector] public int keyOneCount = 0;
    [HideInInspector] public int keyPlusCount = 0;
    [HideInInspector] public int keyEqualCount = 0;
    public List<GameObject> Keys;
    public bool bossRoomOpen = false;

    private void Awake()
    {
        Instance = this;
        objectPool = GetComponent<ObjectPool>();
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;

        healthSystem = Player.GetComponent<HealthSystem>();

        healthSystem.OnDamage += UpdateHealthUI;
        healthSystem.OnHeal += UpdateHealthUI;
        healthSystem.OnDeath += GameOver;
    }


    private void Update()
    {
        if (keyZeroCount >= 3 && keyOneCount >= 7 && keyPlusCount >= 2 && keyEqualCount >= 1)
            bossRoomOpen = true;
    }

    private void UpdateHealthUI()
    {
        hpSlider.value = healthSystem.CurrentHealth / healthSystem.MaxHealth;
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void GameClear()
    {
        gameClearUI.SetActive(true);
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
