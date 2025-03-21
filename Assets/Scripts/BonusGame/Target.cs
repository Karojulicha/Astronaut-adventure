using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 18;
    private float maxTorque = 2;
    private float xRange = 4;
    private float ySpawnPos = 6;
    private GameBManager gameBonusManager;

    void Start()
    {

        targetRb = GetComponent<Rigidbody>();
        gameBonusManager = GameObject.Find("GameBonusManager").GetComponent<GameBManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameBonusManager.UpdateScore(2);
    }

    private void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
    void Update()
    {

    }
}
