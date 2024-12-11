using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Character player;

    // debug only
    public Vector2 direction;
    public Vector3 mousePosition;
    public Vector3 lookDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction;
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        player.Move(direction);

        //get mouse position 
        mousePosition = Input.mousePosition;
        
        mousePosition.z = -10;
        //mousePosition.z = -Camera.main.transform.position.z;
        //^THIS IS AN OFFSET. inverting the z coordinate,
        //^^will auto adjust this in unity editor with any z value
        
        //convert mouse position to world position 
        Vector3 destination = Camera.main.ScreenToWorldPoint(mousePosition);
        lookDirection =  destination - transform.position;
        //^Camera - player position

        player.Look(lookDirection);
        if (Input.GetMouseButtonDown(0))
        {
            //player.currentWeapon.Shoot(weaponTip);
            player.StartAttack();
            //start shooting
        }
        if (Input.GetMouseButton(0))
        {
            player.Attack();
        }
        if (Input.GetMouseButtonUp(0)) 
        { 
            player.StopAttack();
            //stop shooting
        }
    }

    private void FixedUpdate()
    {
        //ADD FORCE HERE
    }


}
