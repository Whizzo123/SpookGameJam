using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessedSunCannonProjectile : MonoBehaviour
{

    private GameObject target;
    public float projectileSpeed;
    public GameObject impactEffect;
    public Vector3 setPos;
    public float splashRange = 10f;
    public void Seek(GameObject _target)
    {
        target = _target;
        Vector3 dir = target.transform.position - transform.position;
        setPos = dir;
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

        Debug.Log(dir + "vector direction");
        Debug.Log(transform.position + "Our Position");
        Debug.Log(setPos + " target vector");
        //Debug.Log(target.transform.position + "Target position");

        projectileSpeed = this.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        float distanceThisFrame = projectileSpeed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            Debug.Log("HITFUNCTIONISCALLED");
            HitTarget();
            return;
        }
    }

    void HitTarget()
    {

        
        //Gets all enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        List<GameObject> allEnemiesInRange = new List<GameObject>();

        //for all enemies, check if they're in range and put their game objects into another array
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                allEnemiesInRange.Add(enemy.gameObject);//TODO
            }
        }
        //for all gameobjects in array, call damage function
        for (int p = 0; p < allEnemiesInRange.Count; p++)
        {
            //allEnemiesInRange[i]; call damage
        }

        //Effects and destroy ball
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2);
        Destroy(this.gameObject);
        Debug.Log("Hit");
    }

    private void FireCannonAtPoint(Vector3 point)
    {
        var velocity = BallisticVelocity(point, 70);
        Debug.Log("Firing at " + point + " velocity " + velocity);

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

