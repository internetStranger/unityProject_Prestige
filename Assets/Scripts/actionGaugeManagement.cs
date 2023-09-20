using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionGaugeManagement : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject actionBar1;
    GameObject actionBar2;
    GameObject actionBar3;
    GameObject actionBar4;
    GameObject actionBar5;

    playerScript player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<playerScript>();

        actionBar1 = this.transform.GetChild(0).gameObject;
        actionBar2 = this.transform.GetChild(1).gameObject;
        actionBar3 = this.transform.GetChild(2).gameObject;
        actionBar4 = this.transform.GetChild(3).gameObject;
        actionBar5 = this.transform.GetChild(4).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.remainingActions == 5)
        {
            actionBar1.SetActive(true);
            actionBar2.SetActive(true);
            actionBar3.SetActive(true);
            actionBar4.SetActive(true);
            actionBar5.SetActive(true);
        }else if (player.remainingActions == 4)
        {
            actionBar1.SetActive(true);
            actionBar2.SetActive(true);
            actionBar3.SetActive(true);
            actionBar4.SetActive(true);
            actionBar5.SetActive(false);
        }else if (player.remainingActions == 3)
        {
            actionBar1.SetActive(true);
            actionBar2.SetActive(true);
            actionBar3.SetActive(true);
            actionBar4.SetActive(false);
            actionBar5.SetActive(false);
        }else if (player.remainingActions == 2)
        {
            actionBar1.SetActive(true);
            actionBar2.SetActive(true);
            actionBar3.SetActive(false);
            actionBar4.SetActive(false);
            actionBar5.SetActive(false);
        }else if (player.remainingActions == 1)
        {
            actionBar1.SetActive(true);
            actionBar2.SetActive(false);
            actionBar3.SetActive(false);
            actionBar4.SetActive(false);
            actionBar5.SetActive(false);
        }
        else
        {
            actionBar1.SetActive(false);
            actionBar2.SetActive(false);
            actionBar3.SetActive(false);
            actionBar4.SetActive(false);
            actionBar5.SetActive(false);
        }

    }
}
