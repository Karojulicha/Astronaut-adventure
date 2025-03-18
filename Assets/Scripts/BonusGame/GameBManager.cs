using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBManager : MonoBehaviour
{
    public List<GameObject> targets;
    private int score;
    public TextMeshProUGUI scoreText;
    private float spawnRate = 1.0f;
    void Start()
    {
        StartCoroutine(SpawerTarget());
        score = 0;
        UpdateScore(0);
    }

    IEnumerator SpawerTarget()
    {
        while (true)
        {

            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {   
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }
}
