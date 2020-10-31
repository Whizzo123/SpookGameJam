using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    public int waveNumber;
    public WaveTemplate[] waveTemplates;
    public float spawnCooldown;
    private float spawnCooldownTimer;
    public float patrolCooldown;
    private float patrolCooldownTimer;
    public GameObject spawnPos;
    private int enemyCountInWave;
    private bool spawning;
    public GameObject targetGate;
    public List<GameObject> enemiesInWave;
    public GameObject hellSpawnGameObject;


    private int waveIndex;
    private int patrolIndex;
    private int memberIndex;

    void Start()
    {
        waveNumber = 0;

        StartWave();
    }

    public void StartWave()
    {
        spawnCooldownTimer = 0;
        spawning = true;
        waveIndex = 0;
        patrolIndex = 0;
        memberIndex = 0;
    }

    void Update()
    {
        if (patrolCooldownTimer < 0)
        {
            if (spawnCooldownTimer <= 0)
            {
                spawnCooldownTimer = spawnCooldown;
                WaveTemplate waveTemplate = waveTemplates[waveNumber];
                if (waveIndex < waveTemplate.patrols.Length)
                {
                    PatrolTemplate patrol = waveTemplate.patrols[waveIndex];
                    Debug.Log("WaveTemplate patrols length: " +  waveTemplate.patrols.Length);
                    if (patrolIndex < patrol.members.Length)
                    {
                        PatrolMember member = patrol.members[patrolIndex];
                        if (memberIndex < member.numberToSpawn)
                        {
                            SpawnEnemy(member.enemyTemplate);
                            memberIndex++;
                        }
                        else
                        {
                            memberIndex = 0;
                            patrolIndex++;
                        }
                    }
                    else
                    {
                        patrolCooldownTimer = patrolCooldown;
                        patrolIndex = 0;
                        waveIndex++;
                    }
                }
            }
            else
            {
                Debug.Log("Spawn cooldown timer:  " + spawnCooldownTimer);
                spawnCooldownTimer -= Time.deltaTime;
            }
        }
        else
        {
            Debug.Log("Patrol cooldown timer: " + patrolCooldownTimer);
            patrolCooldownTimer -= Time.deltaTime;
        }
        
        
    }

    private void SpawnEnemy(GameObject enemyTemplate)
    {
        GameObject go = (GameObject)Instantiate(enemyTemplate, spawnPos.transform.position, Quaternion.identity);
        go.GetComponent<Navigate>().targetPos = targetGate;
        go.GetComponent<enemy>().hellSpawnLocation = hellSpawnGameObject;
        enemiesInWave.Add(go);
        enemyCountInWave++;
    }

    public void EnemyHasBeenKilled()
    {
        enemyCountInWave--;
        if(enemyCountInWave == 0)
        {
            //Wave over
            waveNumber++;
        }
    }
}

[System.Serializable]

public struct PatrolTemplate
{
    public PatrolMember[] members;
}
[System.Serializable]
public struct PatrolMember
{
    public GameObject enemyTemplate;

    public int numberToSpawn;
}
[System.Serializable]
public struct WaveTemplate
{
    public PatrolTemplate[] patrols;
}