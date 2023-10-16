using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Regular movement speed

    [SerializeField] private float sprintSpeed = 10f; // Sprinting speed

    //[SerializeField] private float rotationSpeed = 10f; // Rotation speed
    [SerializeField] private GameObject Bullet; //Bullet prefab
    [SerializeField] private float BulletSpeed = 100f;  //Bullet speed
    [SerializeField] private Transform bulletSpawn; //Spawn location of bullet (from player prefab)
    [SerializeField] private Animator SpriteZ;
    [SerializeField] private Animator SpriteX;
    private GameManager dungeonMaster;
    private Rigidbody rb;
    private Vector3 moveInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        dungeonMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        //Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the game window
    }

    private void Update()
    {
        // Input handling
        float horizontalInput = Input.GetAxis("Vertical") * -1; //Flipping these because of camera angle. Stupid super stupid idea
        float verticalInput = Input.GetAxis("Horizontal");

        moveInput = new Vector3(horizontalInput, 0f, verticalInput);

        // Rotate the character based on mouse input
        //float mouseX = Input.GetAxis("Mouse X");
        //Vector3 rotation = transform.localRotation.eulerAngles;
        //rotation.y += mouseX * rotationSpeed * Time.deltaTime;
        //transform.localRotation = Quaternion.Euler(rotation);

        if (Input.GetKeyDown(KeyCode.UpArrow)){
            rb.transform.eulerAngles = new Vector3(0f, 270f, 0f);
            fire();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            rb.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            fire();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            rb.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            fire();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            rb.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            fire();
        }

    }

    private void fire(){
        GameObject newBullet = Instantiate(Bullet, bulletSpawn.position, Quaternion.Euler(90f, rb.transform.eulerAngles.y, 0f));
        Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
        BulletRB.velocity = this.transform.forward * BulletSpeed;
    }

    private void FixedUpdate()
    {
        // Move the character
        Vector3 moveDirection = Quaternion.Euler(0f, 0f, 0f) * moveInput;
        Vector3 moveVelocity;

        // Run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveVelocity = moveDirection * sprintSpeed;
        }
        else
        {
            moveVelocity = moveDirection * moveSpeed;
        }
        
        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
        if (moveInput.sqrMagnitude != 0){
            SpriteZ.SetBool("Walking", true);
            SpriteX.SetBool("Walking", true);
        } else {
            SpriteZ.SetBool("Walking", false);
            SpriteX.SetBool("Walking", false);
        }
        
    }

    private void OnTriggerEnter(Collider other){

        if (other.gameObject.tag == "Enemy"){
            dungeonMaster.damagePlayer();
            Destroy(other.gameObject);
        }

    }

}