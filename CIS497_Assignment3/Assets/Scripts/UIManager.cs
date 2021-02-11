using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text gameOver;
    public Text changes;
    public Text tutorial;
    public GameManager gm;


    void Awake()
    {
        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameStarted)
        {
            tutorial.enabled = false;
        }

        changes.text = "Changes: " + gm.numChanges.ToString();

        if (gm.gameOver)
        {
            if (gm.gameWon)
            {
                gameOver.text = "Game Over! You Win!\nPress R to restart.";
            }
            else
            {
                gameOver.text = "Game Over! You Lose!\nPress R to restart.";
            }
            gameOver.enabled = true;
        }
    }
}
