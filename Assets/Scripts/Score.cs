using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    static int currentScore;
    [SerializeField] TMPro.TextMeshProUGUI scoreText;

    void Start()
    {
        currentScore = 0;
        scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        if (scoreText == null)
        {
            Debug.LogError("Score Text not found!");
        }
    }

    private void Update()
    {
        scoreText.text = currentScore.ToString();
    }

    static public void AddScore(int score)
    {
        currentScore += score;
    }
}
