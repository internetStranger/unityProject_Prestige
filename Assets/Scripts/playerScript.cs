using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator myAnim;

    Rigidbody2D rb;

    float walkSpeed = 4f;

    float inputHorizontal;
    float inputVertical;

    private float attackTime;
    private float attackCounter;
    private bool isAttacking;

    public bool moving;
    public float tileX;
    public float tileY;
    float offset;

    float newX;
    float newY;

    public int actions;
    public int remainingActions;

    private EnemyHealth enemyHealthManager;
    private GameObject enemy;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        offset = 0.1f;

        attackTime = 0.25f;
        attackCounter = 0.25f;
        isAttacking = false;

        enemyHealthManager = FindObjectOfType<EnemyHealth>();
        enemy = GameObject.Find("Enemy");

        actions = 5;
        remainingActions = actions;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            rb.velocity = Vector3.zero;
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                myAnim.SetBool("isHeavyAttacking", false);
                myAnim.SetBool("isLightAttack", false);
                myAnim.SetFloat("tileY", 0);
                myAnim.SetFloat("tileX", 0);
                isAttacking = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            if (this.transform.position.x < tileX - offset)
            {
                inputHorizontal = 1;
                inputVertical = 0;
                myAnim.SetBool("incoming", true);
                myAnim.SetFloat("moveX", inputHorizontal);
                myAnim.SetFloat("moveY", inputVertical);
                rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);

            }
            else if (this.transform.position.x > tileX + offset)
            {
                inputHorizontal = -1;
                inputVertical = 0;
                myAnim.SetBool("incoming", true);
                myAnim.SetFloat("moveX", inputHorizontal);
                myAnim.SetFloat("moveY", inputVertical);
                rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);

            }
            else if(this.transform.position.y < tileY - offset)
            {
                inputVertical = 1;
                inputHorizontal = 0;
                myAnim.SetBool("incoming", true);
                myAnim.SetFloat("moveX", inputHorizontal);
                myAnim.SetFloat("moveY", inputVertical);
                rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);

            }
            else if (this.transform.position.y > tileY + offset)
            {
                inputVertical = -1;
                inputHorizontal = 0;
                myAnim.SetBool("incoming", true);
                myAnim.SetFloat("moveX", inputHorizontal);
                myAnim.SetFloat("moveY", inputVertical);
                rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);
            }
            else
            {
                inputHorizontal = 0;
                inputVertical = 0;
                myAnim.SetBool("incoming", false);
                rb.velocity = Vector2.zero;
                moving = false;

                newX = Mathf.RoundToInt(this.transform.position.x);
                newY = Mathf.RoundToInt(this.transform.position.y);

                this.transform.position = new Vector3(newX, newY, 0);

                Debug.Log("Remaining Moves: " + remainingActions);
            }
                
        }
    }

    public void Attack(string s, string p)
    {
        switch (s)
        {
            case ("Up"):
                myAnim.SetFloat("tileY", 1);

                //if enemy is above the player
                if (transform.position.y + 1 == enemy.transform.position.y && transform.position.x == enemy.transform.position.x)
                {
                    if(p == "heavy")
                        enemyHealthManager.AttackEnemy(30); //damage enemy
                    else
                        enemyHealthManager.AttackEnemy(10); //damage enemy
                }
                break;

            case ("Left"):
                myAnim.SetFloat("tileX", -1);

                //if enemy is left of player
                if (transform.position.x - 1 == enemy.transform.position.x && transform.position.y == enemy.transform.position.y)
                {
                    if (p == "heavy")
                        enemyHealthManager.AttackEnemy(30); //damage enemy
                    else
                        enemyHealthManager.AttackEnemy(10); //damage enemy
                }
                break;

            case ("Down"):
                myAnim.SetFloat("tileY", -1);

                //if enemy is below the player
                if (transform.position.y - 1 == enemy.transform.position.y && transform.position.x == enemy.transform.position.x)
                {
                    if (p == "heavy")
                        enemyHealthManager.AttackEnemy(30); //damage enemy
                    else
                        enemyHealthManager.AttackEnemy(10); //damage enemy
                }
                break;

            case ("Right"):
                myAnim.SetFloat("tileX", 1);

                //if player is right of player
                if (transform.position.x + 1 == enemy.transform.position.x && transform.position.y == enemy.transform.position.y)
                {
                    if (p == "heavy")
                        enemyHealthManager.AttackEnemy(30); //damage enemy
                    else
                        enemyHealthManager.AttackEnemy(10); //damage enemy
                }
                break;
        }

        attackCounter = attackTime;

        if (p == "light")
        {
            myAnim.SetBool("isLightAttack", true);
            remainingActions -= 1;
        }
        else if(p == "heavy")
        {
            myAnim.SetBool("isHeavyAttacking", true);
            remainingActions -= 2;
        }
        isAttacking = true;
    }

}
