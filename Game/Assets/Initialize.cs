using UnityEngine;
using System.Collections;

public class Initialize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Physics.gravity = new Vector3(0, 0, 9.81f);	
        Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Application.LoadLevel(Application.loadedLevel);

        //}
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel(0);
	}
}
