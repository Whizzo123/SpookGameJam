using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistOfJusticeTower : Tower
{
  
    private void Update()
    {
        //Doesn't continue and wastes computing power if no target
        if (target == null)
        {
            return;
        }

        //Big brain stuff for rotating tower to look at target
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        towerRotate.rotation = Quaternion.Euler(0f, rotation.y - 180, 0);

        //Tower rate of fire
        if (towerCountdown <= 0f)
        {
            Shoot();
            towerCountdown = 1f / towerRate;
        }
        towerCountdown -= Time.deltaTime;

    }

    public void Shoot()
    {
        GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        FistOfJusticeProjectile projectile = projectileGO.GetComponent<FistOfJusticeProjectile>();

        if (projectile != null)
        {
            projectile.Seek(target);
        }
    }
}
