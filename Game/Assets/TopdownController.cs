using UnityEngine;
using System.Collections;

public class TopdownController : MonoBehaviour 
{
    public Joystick moveJoystick;
    public Slingshot sling;

    public float speed = 5;								// Ground speed
    public float jumpSpeed = 8;
    public float inAirMultiplier = 0.25f; 				// Limiter for ground speed while jumping
    public bool alive = true;

    private Transform thisTransform;
    private Vector3 velocity;						// Used for continuing momentum while in air
    Quaternion zeroQuaternion = new Quaternion(0, 0, 0, 0);

    void Start()
    {
        // Cache component lookup at startup instead of doing this every frame	
        thisTransform = gameObject.GetComponent< Transform >();
        
        // Move the character to the correct start position in the level, if one exists
        var spawn = GameObject.Find( "PlayerSpawn" );
        if ( spawn )
            thisTransform.position = spawn.transform.position;	
    }

   public void OnEndGame()
    {
        // Disable joystick when the game ends	
        moveJoystick.Disable();
        
        // Don't allow any more control changes when the game ends
        this.enabled = false;
    }

   Vector3 previousPosition;
   Quaternion previousRotation;
    public void Update()
    {
        if (moveJoystick.position == Vector2.zero)
        {
            transform.position = previousPosition;
        }
        else
        {
            Vector3 movement = new Vector3(moveJoystick.position.x, 0, moveJoystick.position.y);

            movement.y = 0;
            movement.Normalize(); // Adjust magnitude after ignoring vertical movement

            // Let's use the largest component of the joystick position for the speed.
            Vector2 absJoyPos = new Vector2(Mathf.Abs(moveJoystick.position.x), Mathf.Abs(moveJoystick.position.y));
            movement *= speed * ((absJoyPos.x > absJoyPos.y) ? absJoyPos.x : absJoyPos.y);

            movement += velocity;
            movement += Physics.gravity;
            movement *= Time.deltaTime;

            transform.position += movement;
        }
        previousPosition = transform.position;

        if (alive)
        {
            //Don't trip over
            //Quaternion direction = new Quaternion();
            if (sling.aiming)
            {
                //direction.eulerAngles = new Vector3(-sling.dir.x,-sling.dir.y, -sling.dir.z);
                //transform.rotation = direction;
                transform.rotation = Quaternion.LookRotation(-sling.dir);
                //transform.rotation = rotation; 
                 //sling.dir
            }
            else
            {
                transform.rotation = previousRotation;
            }
        }
        else
        {

        }

        if(transform.position.y <= 0)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            //Debug.Log("ses");
        }
        previousRotation = transform.rotation;
    }
}
