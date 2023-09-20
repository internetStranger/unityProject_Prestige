using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AttackPlayer(int damageAmount)
    {
        //damage calculation
        currentHealth -= damageAmount;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
