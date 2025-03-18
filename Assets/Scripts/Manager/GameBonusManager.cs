using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBonusManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    // public void UpdateScore(int scoreToAdd){
    //     scoreToAdd += scoreToAdd;
    //     scoreText.text = $"Score: {scoreToAdd}";
    // }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
