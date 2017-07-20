using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementRigidBody : MonoBehaviour
{

    Vector3 inputVector; //this variable passes data from Update > FixedUpdate
    Rigidbody rbody;
    public float moveSpeed = 5f;
    public float gravityMeter = -5.0f;
    public float mouseSensitivity = 180f;
    float mouseY; // accumulate Mouse Y data, so we clamp it later too

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //always put input/rendering in regular Update
    void Update()
    {
        //keyboard movement
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = gravityMeter;
        inputVector.z = Input.GetAxis("Vertical");

        //mouse look
        transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0f);
        mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        mouseY = Mathf.Clamp(mouseY, -60f, 60f); // clamping vertical mouse look
        Camera.main.transform.localEulerAngles = new Vector3(mouseY, 0f, 0f); //apply up-down movement

        //hide the mouse cursor
        if (Input.GetMouseButtonDown(0))
        {
            //0= left-click, 1 = right-click, 2 = middle-click
            Cursor.lockState = CursorLockMode.Locked; // locks cursor to middle of screen
            Cursor.visible = false; //actually hides the cursor
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 50f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameDrop");
        }
    }

            //FixedUpdate runs on a fixed interval with the Physics engine
            //Always put physics code in FixedUpdate
            void FixedUpdate()
    {
        //convert inputVector from local space into world space
        //*transform.right" is the capsule's current "right"
        //also see: "transform.TransformDirection()"
        Vector3 worldVector = transform.right * inputVector.x + transform.forward * inputVector.z + transform.up * inputVector.y;

        //AddForce is good for movement that IS NOT walking
        //rbody.AddForce(worldVector * moveSpeed, ForceMode.Force);//actualy apply the force now

        //set velocity directly = is good for walking
        rbody.velocity = worldVector * moveSpeed;
    }

}