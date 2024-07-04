using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    //this entire class goes against almost every proper coding rules, but time is of essence
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject loseCanvas;

    static public bool gameOver = false;

    int remainingEnemies;

    int chalkBonus = 10;

    private void Start()
    {
        remainingEnemies = enemies.Length;
        winCanvas.SetActive(false); 
        loseCanvas.SetActive(false);
    }

    private void Update()
    {
        for (int i = 0; i < remainingEnemies ; i++)
        {
            if (enemies[i] == null)
            {
                enemies[i] = enemies[remainingEnemies - 1];
                remainingEnemies--;
            }
        }
        if (remainingEnemies == 0)
        {
            Score.AddScore(ThrowChalk.throwremaining * chalkBonus);
            ThrowChalk.throwremaining = 0;
            winCanvas.SetActive(true);
            gameOver = true;
        }
        if (ThrowChalk.throwremaining == 0 && remainingEnemies > 0)
        {
            loseCanvas.SetActive(true);
            gameOver = true;
        }
    }
}
