using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessedSunCannonProjectile : MonoBehaviour
{

    private Vector3 target;
    public float projectileSpeed;
    public GameObject impactEffect;
    public Vector3 setPos;
    public float splashRange = 10f;
    public float damage = 1f;
    public float towerRange = 4f;

    public void Seek(Vector3 _target)
    {
        target = _target;
        Vector3 dir = target - transform.position;
        setPos = target;
        FireCannonAtPoint(dir);
    }


    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }


        Vector3 dir = setPos - transform.position;

        projectileSpeed = this.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        float distanceThisFrame = projectileSpeed * Time.deltaTime;
        Debug.Log(dir.magnitude + "Dir Magnitude\\" + "distanceThisFrame: " + distanceThisFrame);
        if (dir.magnitude <= distanceThisFrame + 1f)
        {
            HitTarget();
            return;
        }
    }

    void HitTarget()
    { 
        //Gets all enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = towerRange;
        List<GameObject> allEnemiesInRange = new List<GameObject>();

        //for all enemies, check if they're in range and put their game objects into another array
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                allEnemiesInRange.Add(enemy.gameObject);
            }
        }
        Debug.Log("Hit Target enemies hit: " + allEnemiesInRange.Count);
        //for all gameobjects in array, call damage function
        for (int p = 0; p < allEnemiesInRange.Count; p++)
        {
            allEnemiesInRange[p].GetComponent<enemy>().SetHealth(-damage);
        }

        //Effects and destroy ball
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2);
        Destroy(this.gameObject);
    }

    private void FireCannonAtPoint(Vector3 point)
    {
        var velocity = BallisticVelocity(point, 70);
        this.gameObject.GetComponent<Rigidbody>().velocity = velocity;
    }
    
    private Vector3 BallisticVelocity(Vector3 destination, float angle)
    {
        Debug.Log("FUCK YOU!");
        Vector3 dir = destination;
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized; // Return a normalized vector.
    }
}

