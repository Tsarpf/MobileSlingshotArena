using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

    public Joystick aimJoystick;
    public Vector3 dir;
    public bool aiming = false;
    GameObject arrow;
    Object projectilePrefab;
    public float projectileSpeedMultiplier = 5;
	// Use this for initialization
	void Start ()
    {
        arrow = GameObject.FindGameObjectWithTag("arrow");
        projectilePrefab = Resources.Load("Sphere");
	}
	
	// Update is called once per frame
                //GameObject newProj = Instantiate(projectilePrefab, transform.position + 2 * (-dir), new Quaternion()) as GameObject;
    GameObject newProj;
    Vector3 oldDir;
    float oldScale;
	void Update ()
    {
        Vector3 movement = new Vector3(aimJoystick.position.x, aimJoystick.position.y, 0);
        float x = Mathf.Abs(aimJoystick.position.x);
        float y = Mathf.Abs(aimJoystick.position.y);
        float scale = Mathf.Max(x,y);

        dir = new Vector3(movement.x, 0, movement.y);


        if (aimJoystick.position == Vector2.zero)
        {
            if(aiming)
            {
                Vector3 speed =  (-oldDir) * projectileSpeedMultiplier * oldScale;
                speed.y = 20.0f;
                newProj.rigidbody.velocity = speed;

            }
            aiming = false;
            scale = 0;

        }
        else 
        {
            if(!aiming)
            {
                newProj = Instantiate(projectilePrefab, transform.position + 2 * (dir), new Quaternion()) as GameObject;
                aiming = true;
            }
            scale += 0.10f;
        }

        arrow.transform.localScale = new Vector3(scale, arrow.transform.localScale.y, arrow.transform.localScale.z);

        if(aiming)
        {
            newProj.transform.position = transform.position + 2 * (dir);
        }

        oldDir = dir;
        oldScale = scale;
    }
}
