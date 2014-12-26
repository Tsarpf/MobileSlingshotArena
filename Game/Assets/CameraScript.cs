using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
    Quaternion initRotation;
    Transform playerTransform;
	void Start () {
        initRotation = transform.rotation;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(playerTransform.position.x, 10, playerTransform.position.z);
        transform.rotation = initRotation;	

	}
}
