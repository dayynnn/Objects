using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Automatic Weapon")]
public class AutoProjectileWeapon : ProjectileWeapon
{
    private float shootDelay;
    //public ProjectileWeapon(Transform tip, GameObject bulletReference) : base(tip)
    //{
    //    projectilePrefab = bulletReference;
    //}

    public override void Reload()
    {
    }

    public override void StartShooting(Transform weaponTip)
    {
        isShooting = true;
        shootDelay += 1 / fireRate;
    }

    public override void StopShooting()
    {
        isShooting = false;
        shootDelay = -1 / fireRate;
    }

    public override void Shoot(Transform weaponTip)
    {
        if (isShooting)
        {
            if (shootDelay >= 1 / fireRate)
            {
                //Instantiate a projectile
                Bullet bulletClone = GameObject.Instantiate(projectilePrefab, weaponTip.position, weaponTip.rotation);
                bulletClone.InitializeBullet(damage);
                shootDelay = 0;
            }
            else
            {
                shootDelay += Time.deltaTime;
            }
        }
    }
}
