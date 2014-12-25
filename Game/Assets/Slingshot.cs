using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

    public Joystick aimJoystick;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	            Vector3 movement = new Vector3(aimJoystick.position.x, aimJoystick.position.y, 0);

                movement.z = 0;
                movement.Normalize(); // Adjust magnitude after ignoring vertical movement

                // Let's use the largest component of the joystick position for the speed.
                //Vector2 absJoyPos = new Vector2(Mathf.Abs(moveJoystick.position.x), Mathf.Abs(moveJoystick.position.y));
                //movement *= speed * ((absJoyPos.x > absJoyPos.y) ? absJoyPos.x : absJoyPos.y);

                //movement += velocity;
                //movement += Physics.gravity;
                //movement *= Time.deltaTime;


                //transform.position += movement;
	}
}
