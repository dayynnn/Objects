using UnityEngine;
public class Enemy : Character
{
    [SerializeField] private float stopDistance = 2.5f;
    [SerializeField] private float attackCooldown = 3f;

    private float attackTimer;
    private Player target;

    protected override void Start()
    {
        base.Start();
        target = FindObjectOfType<Player>();

    }

    private void Update()
    {
        if(!target) return; //if the player is dead

        Vector2 destination = target.transform.position;
        Vector2 currentPosition = transform.position;
        Vector2 direction = destination - currentPosition;

        if (Vector2.Distance(destination, currentPosition) > stopDistance)
        {
            Move(direction.normalized);
        }
        else 
        { 
            Attack(); 
        }

        Look(direction.normalized);
    }

    public override void Attack()
    {
        base.Attack();

        if (attackTimer >= attackCooldown) 
        {
            target.healthValue.DecreaseHealth(1);
            attackTimer = 0;
        }
        else
        {
            attackTimer += Time.deltaTime;
        }
    }
    public override void PlayDeadEffect()
    {
        GameManager.instance.RemoveEnemyFromList(this);
        base.PlayDeadEffect();  
    }
}
