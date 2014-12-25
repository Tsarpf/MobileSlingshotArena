using UnityEngine;
using System.Collections;

public class TopdownController : MonoBehaviour {

//////////////////////////////////////////////////////////////
// CameraRelativeControl.js
// Penelope iPhone Tutorial
//
// CameraRelativeControl creates a control scheme similar to what
// might be found in 3rd person platformer games found on consoles.
// The left stick is used to move the character, and the right
// stick is used to rotate the camera around the character.
// A quick double-tap on the right joystick will make the 
// character jump. 
//////////////////////////////////////////////////////////////


    public Joystick moveJoystick;
    public Joystick rotateJoystick;

    //public Transform cameraPivot;						// The transform used for camera rotation
    //public Transform cameraTransform;					// The actual transform of the camera

    public float speed = 5;								// Ground speed
    public float jumpSpeed = 8;
    public float inAirMultiplier = 0.25f; 				// Limiter for ground speed while jumping

    private Transform thisTransform;
    private CharacterController character;
    private Vector3 velocity;						// Used for continuing momentum while in air
    private bool canJump = true;
    bool alive = true;

    void Start()
    {
        // Cache component lookup at startup instead of doing this every frame	
        thisTransform = gameObject.GetComponent< Transform >();
        character = gameObject.GetComponent<CharacterController>();
        
        // Move the character to the correct start position in the level, if one exists
        var spawn = GameObject.Find( "PlayerSpawn" );
        if ( spawn )
            thisTransform.position = spawn.transform.position;	
    }

   public void OnEndGame()
    {
        // Disable joystick when the game ends	
        moveJoystick.Disable();
        rotateJoystick.Disable();
        
        // Don't allow any more control changes when the game ends
        this.enabled = false;
    }

    public void Update()
    {
        if(alive)
        {

            Quaternion q = new Quaternion(0, 0, 0, 0);
            transform.rotation = q;
        }
        Vector3 movement = new Vector3(moveJoystick.position.x, moveJoystick.position.y, 0);
        // We only want the camera-space horizontal direction
        movement.z = 0;
        movement.Normalize(); // Adjust magnitude after ignoring vertical movement
        
        // Let's use the largest component of the joystick position for the speed.
        Vector2 absJoyPos = new Vector2( Mathf.Abs( moveJoystick.position.x ), Mathf.Abs( moveJoystick.position.y ) );
        movement *= speed * ( ( absJoyPos.x > absJoyPos.y ) ? absJoyPos.x : absJoyPos.y );
        
        // Check for jump
        //if ( character.isGrounded )
        //{
        //    if ( !rotateJoystick.IsFingerDown() )
        //        canJump = true;
            
        //    if ( canJump && rotateJoystick.tapCount == 2 )
        //    {
        //        // Apply the current movement to launch velocity
        //        velocity = character.velocity;
        //        velocity.y = jumpSpeed;
        //        canJump = false;
        //    }
        //}
        //else
        //{			
        //    // Apply gravity to our velocity to diminish it over time
        //    velocity.y += Physics.gravity.y * Time.deltaTime;
            
        //    // Adjust additional movement while in-air
        //    movement.x *= inAirMultiplier;
        //    movement.z *= inAirMultiplier;
        //}
        
        movement += velocity;
        movement += Physics.gravity;
        movement *= Time.deltaTime;

        transform.position += movement;
        
        // Actually move the character
        //character.Move( movement );
        
        //if ( character.isGrounded )
        //    // Remove any persistent velocity after landing
        //    velocity = Vector3.zero;
        
        // Face the character to match with where she is moving
        //FaceMovementDirection();	
        
        // Scale joystick input with rotation speed

        
        // Rotate around the character horizontally in world, but use local space
        // for vertical rotation
        //cameraPivot.Rotate( 0, camRotation.x, 0, Space.World );
        //cameraPivot.Rotate( camRotation.y, 0, 0 );
    }
}
