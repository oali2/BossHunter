using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed;
    public float moveSpeed;
    public float jumpSpeed;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Vector3 jumpInput;

    private Camera mainCamera;

    public GunController theGun;
    
    // Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        myRigidBody.drag = 10;
	}
	
	// Update is called once per frame
	void Update () {
        //movement code
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        jumpInput = new Vector3(0f, Input.GetKeyDown(KeyCode.Space) ? 1: 0, 0f);
        moveVelocity = (moveInput * moveSpeed) + (jumpInput*jumpSpeed);

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength)) {

            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        //shooting code
        if (Input.GetMouseButtonDown(0))
        {
            theGun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            theGun.isFiring = false;
        }
	}

    void FixedUpdate ()
    {
        //myRigidBody.velocity = moveVelocity;
        myRigidBody.AddForce(moveVelocity);
        //float xzSpeed = Vector3.Scale(myRigidBody.velocity, new Vector3(1, 0, 1)).magnitude;
        /*if (xzSpeed > maxSpeed) {
            float xp = myRigidBody.velocity.x / xzSpeed * maxSpeed;
            float yp = myRigidBody.velocity.y;
            float zp = myRigidBody.velocity.z / xzSpeed * maxSpeed;
            myRigidBody.velocity = new Vector3(xp, yp, zp);
        }*/
    }

}
