using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMineralManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject spawnPrefab;
    public GameObject spawnMineral;

    void Start()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(spawnMineral, spawnPoint.position, spawnPoint.rotation);
        }
    }

}
