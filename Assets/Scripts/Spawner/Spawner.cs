using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public TextMeshProUGUI waveText;
    public int waveNumber;
    public int WaveNumber
    {
        get
        {
            return waveNumber;
        }
        set
        {
            waveNumber = value;
            waveText.text = "Wave: " + waveNumber;
        }
    }
    public WaveTemplate[] waves;
    public float spawnCooldown;
    private float spawnCooldownTimer;
    public float patrolCooldown;
    private float patrolCooldownTimer;
    public float waveCooldown;
    private float waveCooldownTimer;
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
        WaveNumber = waveNumber;
    }

    public void StartWave()
    {
        if (spawning == false)
        {
            WaveNumber += 1;
            spawnCooldownTimer = 0;
            spawning = true;
            waveIndex = 0;
            patrolIndex = 0;
            memberIndex = 0;
        }
    }

    void Update()
    {
        if (spawning)
        {
            if (patrolCooldownTimer < 0)
            {
                if (spawnCooldownTimer <= 0)
                {
                    spawnCooldownTimer = spawnCooldown;
                    WaveTemplate waveTemplate = waves[waveNumber - 1];
                    if (waveIndex < waveTemplate.patrols.Length)
                    {
                        PatrolTemplate patrol = waveTemplate.patrols[waveIndex];
                        if (patrolIndex < patrol.patrolComposition.Length)
                        {
                            PatrolMember member = patrol.patrolComposition[patrolIndex];
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
                    else
                    {
                        waveIndex = 0;
                        spawning = false;
                    }
                }
                else
                {
                    spawnCooldownTimer -= Time.deltaTime;
                }
            }
            else
            {
                patrolCooldownTimer -= Time.deltaTime;
            }
        }
        else
        {
            if(enemyCountInWave == 0)
            {
                waveCooldownTimer -= Time.deltaTime;
                if(waveCooldownTimer <= 0)
                {
                    StartWave();
                }
            }
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
            waveCooldownTimer = waveCooldown;
        }
    }
}

#region 
[System.Serializable]

public struct PatrolTemplate
{
    public PatrolMember[] patrolComposition;
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
#endregion