using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] Button startGame;

    [Header("Scene Representative Object")]
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject gameplay;
    // Start is called before the first frame update
    void Start()
    {
        if (startGame == null)
        {
            Debug.LogError("Start Game Button not found!");
        }
        if (startMenu == null)
        {
            Debug.LogError("Start Menu UI not found");
        }
        if (gameplay == null)
        {
            Debug.LogError("Gameplay Object Data not found");
        }
        gameplay.SetActive(false);
        startGame.onClick.AddListener(() => StartTheGame());
    }

    void StartTheGame()
    {
        startMenu.SetActive(false);
        gameplay.SetActive(true);
    }
}
