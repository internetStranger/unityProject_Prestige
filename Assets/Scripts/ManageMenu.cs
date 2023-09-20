using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManageMenu : MonoBehaviour
{
    public bool activate;
    GameLogic game;

    public ManageMenu attackMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        game = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        game = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }

    public void playerHeavyAttack()
    {
        game.heavyAttack = true;
        game.move = false;
    }

    public void playerLightAttack()
    {
        game.lightAttack = true;
        game.move = false;
    }

    public void attack()
    {
        attackMenu.gameObject.SetActive(true);
    }

    public void endTurn()
    {
        game.endOfTurn = true;
    }

}
