using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    GameLogic gameScript;

    GameObject player;
    PlayerHealth pHealth;
    private int playerX, playerY;

    private int actions;
    private int remainingActions;

    private int X, Y;
    private int newX, newY;

    void Start()
    {
        gameScript = GameObject.Find("GameLogic").GetComponent<GameLogic>();

        player = GameObject.Find("Player");
        pHealth = player.GetComponent<PlayerHealth>();

        actions = 2;
    }

    // Update is called once per frame
    void Update()
    {
        X = (int)transform.position.x;
        Y = (int)transform.position.y;

        playerX = (int)player.transform.position.x;
        playerY = (int)player.transform.position.y;

    }

    public int getActions()
    {
        return actions;
    }

    public void actionPhase()
    {
        Debug.Log("Enemy choosing action....");
        
        float dis = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log(dis);

        //if adjacent to player - attack
        if (dis == 1)
        {
            Debug.Log("Attacking player");
            pHealth.AttackPlayer(10);
        }
        //otherwise move closer
        else
        {
            Debug.Log("Moving closer");
            if (playerX < X)//player is left
            {
                Move(X - 1, Y);
            }
            else if (playerX > X) //player is right
            {
                Move(X + 1, Y);
            }
            else if (playerY < Y) //player is below
            {
                Move(X, Y - 1);
            }
            else //player is aboce
            {
                Move(X, Y + 1);
            }
        }
        X = (int)transform.position.x;
        Y = (int)transform.position.y;
    }

    public bool endTurn()
    {
        if (remainingActions > 0)
        {
            Debug.Log("remaining actions: " + remainingActions);
            return false;
        }
        return true;
    }

    private void Move(int x, int y)
    {
        transform.position = new Vector3(x, y, 0);
    }

    public void restoreActions()
    {
        remainingActions = actions;
    }
}
