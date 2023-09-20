using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackEnemy(int damageAmount)
    {
        //damage calculation
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
