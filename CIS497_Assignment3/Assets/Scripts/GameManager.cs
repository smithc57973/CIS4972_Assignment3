using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public bool gameWon;
    public bool gameStarted;
    public int numChanges;
    public int numEnemies;
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameWon = false;
        gameStarted = false;
        numChanges = 10;
        Time.timeScale = 0f;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            gameStarted = true;
            Time.timeScale = 1f;
        }

        numEnemies = pc.observers.Count;
        if (numEnemies == 0)
        {
            gameWon = true;
            gameOver = true;
        }

        if (numChanges <= 0 && numEnemies > 0)
        {
            gameOver = true;
        }
       
        if (gameOver)
        {
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
