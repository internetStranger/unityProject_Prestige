using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class turnCounter : MonoBehaviour
{

    public int currentTurn;

    private Text display;

    // Start is called before the first frame update
    void Start()
    {
        currentTurn = 1;

        display = GetComponent<Text>();

        display.text = ("Turn 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newTurn(int t)
    {
        display.text = "Turn " + t;
    }

}
