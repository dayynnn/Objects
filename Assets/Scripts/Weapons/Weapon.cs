using UnityEngine;
public abstract class Weapon : ScriptableObject
{
    [SerializeField] protected float damage;
    [SerializeField] protected int ammo;
    [SerializeField] protected float fireRate;

    protected bool isShooting;

    //protected - similar to private but children classes can access it too.
    
    public abstract void Shoot(Transform weaponTip);
    public abstract void StartShooting(Transform weaponTip);
    public abstract void StopShooting();

    public abstract void Reload();

    public bool hasAmmo()
    {
        return ammo > 0;
    }


    //public Weapon(Transform tip)
    //{
    //    weaponTip = tip;
    //}
}