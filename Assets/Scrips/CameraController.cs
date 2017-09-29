using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public GameObject player; //reference to the player game object

    private Vector3 offset; //holds offset distance between player and camera


	// Use this for initialization
	void Start () {
        //calculate and store the offset value by getting distance between player and camera.
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate ()
    {
        transform.position = player.transform.position + offset;
    }
}
