using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistOfJusticeProjectile : MonoBehaviour
{

    private Vector3 target;
    private GameObject targetGO;
    public float projectileSpeed = 30f;
    public GameObject impactEffect;
    public float damage;
    public void Seek (GameObject _target)
    {
        targetGO = _target;
        target = _target.transform.position;
    }


    void Update()
    {
        //If target is gone, destroy projectile
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target - transform.position;//Vector 3 from ball to target
        float distanceThisFrame = projectileSpeed * Time.deltaTime;
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
        if (targetGO != null)
        {

            targetGO.GetComponent<enemy>().SetHealth(-damage);
        }
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);//Particle Effects
        Destroy(effectIns, 2);
        Destroy(this.gameObject);

    }
}
