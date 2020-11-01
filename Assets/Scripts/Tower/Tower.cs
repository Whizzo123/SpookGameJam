using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    #region TowerStats
    [Header("TowerStats")]
    [Range(0,20)]
    public int towerCost = 5;
    [Range(0, 2)]
    public float towerRate = 2f;
    protected float towerCountdown = 0f;
    [Range(0, 20)]
    public int towerDamage = 5;
    [Range(0, 20)]
    public int towerRange = 10;
    string towerEffect;// = { "Slow", "Vulnerability", "None" };
    string towerProjectile;// = { "Direct", "Splash" };
    [Space]
    #endregion

    #region EnemyGrabs
    [Header("Enemy")]
    protected GameObject target;
    protected string enemyTag = "Enemy";
    [Space]
    #endregion

    #region ProjectileTower
    [Header("Projectile")]
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    [Space]

    [Header("TowerComponents")]
    public Transform towerRotate;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
    #region GetObject
    /*
    if (this.gameObject.tag == "Fist Of Justice")
    {
        towerCost = 5;
        towerRate = 10;
        towerDamage = 5;
        towerRange = 5;
        towerEffect = "None";
        towerProjectile = "Direct";
    } else if (this.gameObject.tag == "Blessed Sun Cannons")
    {
        towerCost = 5;
        towerRate = 10;
        towerDamage = 5;
        towerRange = 5;
        towerEffect = "None";
        towerProjectile = "Splash";
    }
    else if (this.gameObject.tag == "Cursed Sundial")
    {
        towerCost = 5;
        towerRate = 10;
        towerDamage = 5;
        towerRange = 5;
        towerEffect = "Slow";
        towerProjectile = "Splash";
    }
    else if (this.gameObject.tag == "Holy Water")
    {
        towerCost = 5;
        towerRate = 10;
        towerDamage = 5;
        towerRange = 5;
        towerEffect = "Vulnerability";
        towerProjectile = "Splash";
    }
    else if (this.gameObject.tag == "Cupid Ballista")
    {
        towerCost = 5;
        towerRate = 10;
        towerDamage = 5;
        towerRange = 5;
        towerEffect = "None";
        towerProjectile = "Direct";
    }
    */
    #endregion
    InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }
    
        void UpdateTarget()
        {
        //Finds all enemies with tag 'Enemy'
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortesDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

        //for each enemy in enemies, it will find who is the closest and store that in nearest enemy
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if(distanceToEnemy < shortesDistance)
                {
                    shortesDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            //if the nearest enemy is still alive and it's in range, set it as target
            if (nearestEnemy != null && shortesDistance <= towerRange)
            {
                target = nearestEnemy;
            }
            else
            {
                target = null;
            }
        }

    #region CodeMovedToIndividualCompenents
    /*
        private void Update()
        {
            //Doesn't continue and wastes computing power if no target
            if(target == null)
            {
                return;
            }

            //Big brain stuff for rotating tower to look at target
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = lookRotation.eulerAngles;
            towerRotate.rotation = Quaternion.Euler(0f, rotation.y-180, 0);

            //Tower rate of fire
            if (towerCountdown <= 0f)
            {
                Shoot();
                towerCountdown = 1f / towerRate;
            }
            towerCountdown -= Time.deltaTime;

        }



        public virtual void Shoot()
        {
            GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            Projectile projectile = projectileGO.GetComponent<Projectile>();

            if(projectile != null)
            {
                projectile.Seek(target);
            }
        }
        */
    #endregion

    //Just draws a range for developers to see
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, towerRange);
    }
}
