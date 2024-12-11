using UnityEngine;

public class Player : Character
{
    [SerializeField] private Transform playerWeaponTip;
//    [SerializeField] private GameObject bulletReference;
    //protected override void Start()
    //{
    //    base.Start();
    //    currentWeapon = new ProjectileWeapon(playerWeaponTip, bulletReference);
    //}
    public override void Attack()
    {
        //base.Attack(); delete as it only does Debug.Log...
        currentWeapon.Shoot(playerWeaponTip);
    }

    public override void StartAttack()
    {
        base.StartAttack();
        currentWeapon.StartShooting(playerWeaponTip);
    }

    public override void StopAttack()
    {
        base.StopAttack();
        currentWeapon.StopShooting();
    }

    private void Update()
    {
        Attack();
    }
}
