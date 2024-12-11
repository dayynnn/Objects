using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float health = 10f;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float movementSpeed = 50f;
    
    [SerializeField] private GameObject dieEffect;

    public Health healthValue;
    public Weapon currentWeapon;

    protected virtual void Start()
    {
        healthValue = new Health(health);
        healthValue.OnDeath.AddListener(PlayDeadEffect);
    }
    public void Move(Vector2 direction)
    {
        playerRb.AddForce(direction * Time.deltaTime * movementSpeed, ForceMode2D.Impulse);
    }

    public virtual void Look(Vector2 dir)
    {
        float angle; //= Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = Vector2.SignedAngle(Vector2.up, dir);// alternate way to do that
        playerRb.SetRotation(angle);
        //^changes direction from Red arrow(x-axis) to Green Arrow(y-axis)
    }
    public virtual void PlayDeadEffect()
    {
        Instantiate(dieEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Interact()
    {
        //Debug.Log(GameManager.timer);
    }

    public virtual void Attack() //instantiating bullets
    {
        Debug.Log("Attacking!");
    }

    public virtual void StartAttack() // as i press the mouse button
    {

    }

    public virtual void StopAttack() // when i release the mouse button
    {
        
    }
}
