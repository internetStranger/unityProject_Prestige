using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private playerScript pScript;
    private enemyScript eScript;

    public turnCounter displayTurn;

    public GameObject actionMenu;

    public bool heavyAttack;
    public bool lightAttack;
    public bool move;

    public bool endOfTurn;

    int turnNum;

    void Start()
    {
        heavyAttack= false;
        lightAttack= false;
        move = true;

        pScript = player.GetComponent<playerScript>();

        eScript = GameObject.Find("Enemy").GetComponent<enemyScript>();

        endOfTurn = false;

        turnNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //open menu
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //activate action menu
            actionMenu.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //end the player turn
            endOfTurn = true;
        }

        if (Input.GetKeyDown(KeyCode.Z)) //heavy attack hot key
        {
            //heavy attack
            heavyAttack = true;
            move = false;
        }
        if (Input.GetKeyDown(KeyCode.X)) //light attack hot key
        {
            //light attack
            lightAttack = true;
            move = false;
        }

        if (endOfTurn)
        {
            //enemy moves
            Debug.Log("Enemy turn");
            for(int i = 0; i < eScript.getActions(); i++)
            {
                eScript.actionPhase();
            }

            eScript.restoreActions();

            //allies move
            pScript.remainingActions = pScript.actions;

            turnNum++;
            displayTurn.newTurn(turnNum);

            endOfTurn = false;
        }

    }
}
