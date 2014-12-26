using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

    public Joystick aimJoystick;
    public Vector3 dir;
    public bool aiming = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 movement = new Vector3(aimJoystick.position.x, aimJoystick.position.y, 0);

        dir = new Vector3(movement.x, 0, movement.y);

        if (aimJoystick.position == Vector2.zero)
        {
            aiming = false;
        }
        else
        {
            aiming = true;
        }



        if(aiming)
        {
            //Vector3 relativePos = target.position - transform.position;
        }
    }
}
