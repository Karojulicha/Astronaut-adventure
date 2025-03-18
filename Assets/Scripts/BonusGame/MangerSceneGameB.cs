using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MangerSceneGameB : MonoBehaviour
{
    public GameObject powerUpLife;


    void OnTriggerEnter()
    {
        startGameBonus();
    }

    public void OnTriggerExit(Collider other)
    {
        powerUpLife = GameObject.Find("PrefabPowerUpLife");
        if (other.CompareTag("Player"))
        {
            Destroy(powerUpLife);
        }
    }

    public void startGameBonus()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("GameBonus");
    }

    public void EndGameBonus()
    {
        SceneManager.LoadScene("GameFirstScene");
        Time.timeScale = 1;
    }
}
