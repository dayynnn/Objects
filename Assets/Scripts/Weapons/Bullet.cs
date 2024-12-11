using UnityEngine;
using System;
using Unity.VisualScripting;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRb;
    [SerializeField] private float bulletSpeed;
    private float myDamage;

    // Start is called before the first frame update
    void Start()
    {
        myRb.velocity = transform.up * bulletSpeed;
    }

    public void InitializeBullet(float damageParam)
    {
        myDamage = damageParam;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //FindObjectOfType<Character>(); finds any character in the hierarchy
        //GetComponent<Character>(); It'll try to find a character in the bullet inspector that calls
        
        if (coll.rigidbody && coll.rigidbody.CompareTag("Enemy"))
        {
            coll.rigidbody.GetComponent<Character>().healthValue.DecreaseHealth(myDamage);
        }
        Destroy(gameObject);
    }

}
