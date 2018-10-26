using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour {

    public bool isFiring;
    public ProjectileController projectile;

    public float projectileSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

	void Update () {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                ProjectileController newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                newProjectile.speed = projectileSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }
	}
}
