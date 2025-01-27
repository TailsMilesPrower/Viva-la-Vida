using UnityEngine;

public class Movement : MonoBehaviour
{
    //A refrence to the player Rigidbody
    public Rigidbody rb;

    //A Vector3 which will be used to calculate the direction the player moves
    private Vector3 moveDirection;

    //Input values
    private float verticalInput;
    private float horizontalInput;
    //Movement speeds
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    //The speed that the player rotates in
    public float rotationSpeed;
    //The maximum speed that the player can reach
    public float maxSpeed;
    //A value which will be used to apply drag to the player, to stop them from sliding across the floor
    public float groundDrag;

    //A refrence to the gun
    public GameObject gun;
    public GameObject gunShaft;
    //A refrence to the inventory screen
    public GameObject inventoryScreen;

    //A bool which will be used to check if the player is aiming
    public bool aiming;

    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        backing
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //Calling the input function
        MyInput();
        //Calling the state function
        StateHandler();
        //Calling the function that limits the player's movement speed, so the player doesn't accelerate infinetly
        SpeedControl();

        //Applying the drag to the Rigidbody
        rb.linearDamping = groundDrag;

        //When the player holds down the RMB, the gun appears and the player starts aiming
        if(Input.GetMouseButton(1))
        {
            aiming = true;
            gun.GetComponent<Renderer>().enabled = true;
            gunShaft.GetComponent<Renderer>().enabled = true;
        }
        //If the player is not holding down the RMB, the gun is not visible
        else
        {
            aiming = false;
            gun.GetComponent<Renderer>().enabled = false;
            gunShaft.GetComponent<Renderer>().enabled = false;
        }
        //Pressing the Tab key either opens the inventory screen, or closes it, depending on what its status is
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(inventoryScreen.activeSelf == false)
            {
                inventoryScreen.SetActive(true);
            }
            else
            {
                inventoryScreen.SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        //Calling the movement function
        MovePlayer();
    }

    //This is a function that handles what state the player is in, aka how fast they are moving
    private void StateHandler()
    {
        //Holding down left shift means the player is sprinting, meaning they move faster
        if(Input.GetKey(KeyCode.LeftShift))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }
        //Holding down the S key means the player is going in reverse, meaning they move slower
        else if(Input.GetKey(KeyCode.S))
        {
            state = MovementState.backing;
            moveSpeed = walkSpeed / 2;
        }
        //Otherwise, the player moves at normal speed
        else
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
    }

    //A function that takes care of the inputs
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //This rotates the player if they hold down the horizontal inputs
        transform.Rotate(0, (horizontalInput * rotationSpeed * Time.deltaTime), 0);
    }

    //A function that takes care of movement
    private void MovePlayer()
    {
        //Calculate the movement direction
        moveDirection = transform.forward * verticalInput;

        //Player can only move if they are not aiming their gun
        if(aiming == false)
        {
            //Moves the player in the calculated direction at an increased movement speed
            rb.AddForce((moveDirection.normalized * moveSpeed * 10f), ForceMode.Force);
        }
    }

    //A function that prvents the player from going too fast
    private void SpeedControl()
    {
        //Calculates the X and Z velocity that the player is moving in
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //Limit the velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }
}
