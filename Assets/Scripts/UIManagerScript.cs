using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{

    private PlayerHealth playerHealthManager;
    public Slider HealthBar;

    private EnemyHealth EnemyHealthManager;
    public Slider EnemyHealthBar;

    public GameObject player;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthManager = FindAnyObjectByType<PlayerHealth>();
        EnemyHealthManager = FindAnyObjectByType<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.maxValue = playerHealthManager.maxHealth;
        HealthBar.value = playerHealthManager.currentHealth;

        EnemyHealthBar.maxValue = EnemyHealthManager.maxHealth;
        EnemyHealthBar.value = EnemyHealthManager.currentHealth;
    }
}
