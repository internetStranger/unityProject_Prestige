using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour
{

    [SerializeField] private GameObject highlight;
    [SerializeField] private GameObject attackHighlight;
    GameObject p;
    playerScript s;

    GameLogic game;

    void Start()
    {
        p = GameObject.Find("Player");
        s = p.GetComponent<playerScript>();
        game = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }

    void Update()
    {

    }

    private void OnMouseEnter()
    {
        if (game.move) 
        {
            highlight.SetActive(true);
            attackHighlight.SetActive(false);
        }
        else if(game.lightAttack || game.heavyAttack)
        {
            highlight.SetActive(false);
            attackHighlight.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
        attackHighlight.SetActive(false);
    }

    private void OnMouseOver()
    {
        #region Highlights
        if (game.move)
        {
            highlight.SetActive(true);
            attackHighlight.SetActive(false);
        }
        else if(game.heavyAttack || game.lightAttack)
        {
            highlight.SetActive(false);
            attackHighlight.SetActive(true);
        }
        #endregion

        #region Attacking

        if (game.heavyAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(s.remainingActions > 1)
                {
                    Debug.Log("heavy attack...");
                    if (this.transform.position.x > p.transform.position.x)
                    {
                        s.Attack("Right", "heavy");
                    }
                    if (this.transform.position.x < p.transform.position.x)
                    {
                        s.Attack("Left", "heavy");
                    }
                    if (this.transform.position.y > p.transform.position.y)
                    {
                        s.Attack("Up", "heavy");
                    }
                    if (this.transform.position.y < p.transform.position.y)
                    {
                        s.Attack("Down", "heavy");
                    }
                    game.heavyAttack = false;
                    game.move = true;
                }
                else
                {
                    Debug.Log("Not enough actions");
                    game.heavyAttack = false;
                    game.move = true;
                }
                
            }
        }

        else if (game.lightAttack && s.remainingActions > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("light attack...");
                if (this.transform.position.x > p.transform.position.x)
                {
                    s.Attack("Right", "light");
                }
                if (this.transform.position.x < p.transform.position.x)
                {
                    s.Attack("Left", "light");
                }
                if (this.transform.position.y > p.transform.position.y)
                {
                    s.Attack("Up", "light");
                }
                if (this.transform.position.y < p.transform.position.y)
                {
                    s.Attack("Down", "light");
                }
                game.lightAttack = false;
                game.move = true;
            }
        }

        #endregion

        #region Movement
        else if (game.move && s.remainingActions > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("moving...");

                int dis = 0;
                if(p.transform.position.x != transform.position.x)
                {
                    if (transform.position.x < p.transform.position.x)
                        dis -= (int)(transform.position.x - p.transform.position.x);
                    else
                        dis -= (int)(p.transform.position.x - transform.position.x);
                }
                if(p.transform.position.y != transform.position.y)
                {
                    if (transform.position.y < p.transform.position.y)
                        dis -= (int)(transform.position.y - p.transform.position.y);
                    else
                        dis -= (int)(p.transform.position.y - transform.position.y);
                }

                if(dis > s.remainingActions)
                {
                    Debug.Log("Not enough actions");
                }
                else
                {
                    s.moving = true;
                    s.tileX = transform.position.x;
                    s.tileY = transform.position.y;
                    s.remainingActions -= dis;
                }
            }
        }
        #endregion

        if (Input.GetMouseButtonDown(0) && s.remainingActions == 0)
        {
            Debug.Log("OUT OF ACTIONS");
            game.heavyAttack = false;
            game.lightAttack = false;
            game.move = true;
        }
    }
}
