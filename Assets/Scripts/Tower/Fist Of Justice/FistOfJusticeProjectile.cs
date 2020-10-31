using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistOfJusticeProjectile : MonoBehaviour
{

    private GameObject target;
    public float projectileSpeed = 100f;
    public GameObject impactEffect;
    public void Seek (GameObject _target)
    {
        target = _target;
    }


    void Update()
    {
        //If target is gone, destroy projectile
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;//Vector 3 from ball to target
        float distanceThisFrame = projectileSpeed * Time.deltaTime;


        Debug.Log(transform.position + "Our Position");
        Debug.Log(target.transform.position + "Target position");
        Debug.Log(dir + "vector direction");
        Debug.Log(distanceThisFrame + "DistanceThisFrame");
        //If magnitude of vector 3 is smaller than the estimated time to reach ball, call hit and don't move
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        //move in a straight path to target using vector 3
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        //Damage Target in here
        target.GetComponent<enemy>().SetHealth(-1);
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);//Particle Effects
        Destroy(effectIns, 2);
        Destroy(this.gameObject);

    }
}
