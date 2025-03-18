using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    
    public Transform[] spawnPoints;
    private Transform playerTransform;
    public float speed = 2f;
    Vector3 playerGroundPos;
    public int maxMonsters = 2;
    public int maxMonstersDangerous = 1;
    private int currentMonsterCount = 0;

    private List<GameObject> monsterInstances = new List<GameObject>();


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (monsterPrefab != null)
        {
            foreach (GameObject monster in monsterInstances)
            {
                MoveTowardsPlayer(monster);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnMonster();
        }

    }
    private void SpawnMonster()
    {
        int numberRandom = Random.Range(1, 5);

        if (currentMonsterCount < maxMonsters)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                GameObject newMonster = Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
                monsterInstances.Add(newMonster);
                currentMonsterCount++;

            }
        }
        // Asegurar que cuando el monster muera, se reduzca el contador. 
    }

    private void MoveTowardsPlayer(GameObject monster)
    {
        float speedUse = monster.CompareTag("MonsterDangerous") ? speed + 1 : speed;

        playerGroundPos = new Vector3(playerTransform.position.x, monster.transform.position.y, playerTransform.position.z);
        if (playerTransform != null)
        {
            monster.transform.position = Vector3.MoveTowards(monster.transform.position, playerGroundPos, speedUse * Time.deltaTime);
        }

        RotateTowardsPlayer(monster.transform);
    }

    private void RotateTowardsPlayer(Transform monster)
    {
        Vector3 direction = (playerTransform.position - monster.position).normalized;
        if (direction != Vector3.zero)
        {

            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            monster.rotation = Quaternion.Slerp(monster.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

}
