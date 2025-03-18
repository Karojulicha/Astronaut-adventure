using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLife : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject spawnPowerUpLifePrefab;
    void Start()
    {

        foreach (Transform point in spawnPoints)
        {
            Instantiate(spawnPowerUpLifePrefab, point.position, point.rotation);
        }

    }

    

    // private (int, int) selectTwoPoints()
    // {
    //     int indexOne;
    //     int indexTwo;
    //     if (spawnPoints.Length >= 2)
    //     {
    //         indexOne = Random.Range(0, spawnPoints.Length);
    //         do
    //         {
    //             indexTwo = Random.Range(0, spawnPoints.Length);
    //         } while (indexOne != indexTwo);
    //     }
    //     return (indexOne, indexTwo);
    // }

}
