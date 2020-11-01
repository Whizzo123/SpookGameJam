using UnityEngine;
using System.Collections;


public class HolyWaterTower : Tower
{

    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        towerRotate.rotation = Quaternion.Euler(0f, rotation.y - 180, 0);

        if(towerCountdown <= 0f)
        {
            Shoot();
            towerCountdown = 1f / towerRate;
        }

        towerCountdown -= Time.deltaTime;
    }

    public void Shoot()
    {
        GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        HolyWaterProjectile projectile = projectileGO.GetComponent<HolyWaterProjectile>();
        projectile.damage = towerDamage;
        projectile.towerRange = towerRange;
        if(projectile != null)
        {
            projectile.Seek(target.transform.position);
        }
    }

}
