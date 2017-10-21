using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    public GameObject target;
    public BulletController projectile;

    public float maximumLookDistance;
    public float maximumAttackDistance;
    public float minimumDistanceFromPlayer;

    public float rotationDamping = 2.0f;

    public float shotInterval = 0.5f;

    public float shotTime = 0;

    public float bulletSpeed;

    void LookAtTarget()
    {
        var dir = target.transform.position - transform.position;
        dir.y = 0;
        var rotation = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 
                                                Time.deltaTime * rotationDamping);
    }

    void Shoot()
    {
        //Reset time when shot fired.
        shotTime = Time.time;

        BulletController newProjectile = Instantiate(projectile, 
                    transform.position + (target.transform.position - transform.position).normalized, 
                    Quaternion.LookRotation(target.transform.position - transform.position));
        newProjectile.speed = bulletSpeed;
        newProjectile.damage = 10;
    }

	void Update () {

        var distance = Vector3.Distance(target.transform.position, transform.position);

        if (distance <= maximumLookDistance)
        {
            LookAtTarget();

            //Check distance and time
            if (distance <= maximumAttackDistance && (Time.time - shotTime) > shotInterval)
            {
                Shoot();
            }
        }
	}
}
