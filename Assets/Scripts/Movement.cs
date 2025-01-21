using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;

    private Vector3 moveDirection;

    private float verticalInput;
    private float horizontalInput;
    private float moveSpeed;

    public float walkSpeed;
    public float sprintSpeed;
    public float rotationSpeed;
    public float maxSpeed;
    public float groundDrag;

    public GameObject gun;
    public GameObject gunShaft;
    public GameObject inventoryScreen;

    public bool aiming;

    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        backing
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        StateHandler();
        SpeedControl();

        rb.linearDamping = groundDrag;

        if(Input.GetMouseButton(1))
        {
            aiming = true;
            gun.GetComponent<Renderer>().enabled = true;
            gunShaft.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            aiming = false;
            gun.GetComponent<Renderer>().enabled = false;
            gunShaft.GetComponent<Renderer>().enabled = false;
        }
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
        MovePlayer();
    }

    private void StateHandler()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            state = MovementState.backing;
            moveSpeed = walkSpeed / 2;
        }
        else
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput == 0)
        {
            verticalInput = Input.GetAxisRaw("Vertical");
        }
        else
        {
            verticalInput = 0;
        }

        if(verticalInput == 0)
        {
            transform.Rotate(0, (horizontalInput * rotationSpeed * Time.deltaTime), 0);
        }
    }

    private void MovePlayer()
    {
        //Calculate the movement direction
        moveDirection = transform.forward * verticalInput;

        if(aiming == false)
        {
            rb.AddForce((moveDirection.normalized * moveSpeed * 10f), ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //Limit the velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }
}
