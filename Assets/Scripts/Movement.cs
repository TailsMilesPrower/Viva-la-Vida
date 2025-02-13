using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private static Movement instance;

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

    //This defines the health changed events and handler delagating
    public delegate void HealthChangedHandler(object source, float oldHealth, float newHealth);
    public event HealthChangedHandler OnHealthChanged;

    [SerializeField]
    float currentHealth;
    float maxHealth = 20f;
    float damage = 10f;
    float healing = 10f;

    public float CurrentHealth => currentHealth;

    [SerializeField]
    float testHealAmount = 5f;
    [SerializeField]
    float testDamageAmount = -5f;

    public void ChangeHealth(float amount)
    {
        float oldHealth = currentHealth;
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(this, oldHealth, currentHealth);

        // Checks if health has reached zero
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Death scene");
        }

    }

    void ApplyHealing()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Min(currentHealth + healing, maxHealth);
        }
    }

    public void DamageHealth()
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;

            // Checks if health is zero and changes scene
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("Death scene");
            }
        }
    }

    public enum MovementState
    {
        walking,
        sprinting
    }

    //A refrence to the game manager
    public GameObject gameManager;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Awake()
    {
        // This code is used to make sure there are never more than one player
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //If the game manager is set to null, the script will find it and assign it
        if (gameManager == null)
        {
            gameManager = GameObject.Find("GameManager");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "TutorialScene")
        {
            Destroy(this.gameObject);
        }

        //Calling the input function
        MyInput();
        //Calling the state function
        StateHandler();
        //Calling the function that limits the player's movement speed, so the player doesn't accelerate infinetly
        SpeedControl();

        rb.linearDamping = groundDrag;

        //When the player holds down the RMB, the gun appears and the player starts aiming
        if (Input.GetMouseButton(1))
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
        if(Input.GetKeyDown(KeyCode.I))
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

        if (Input.GetKeyDown(KeyCode.H))
        {
            DamageHealth();
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

        /*if(aiming)
        {
            //This rotates the player if they hold down the horizontal inputs
            transform.Rotate(0, (horizontalInput * rotationSpeed * Time.deltaTime), 0);
        }*/
    }

    //A function that takes care of movement
    private void MovePlayer()
    {
        //moveDirection = (cam.transform.forward * verticalInput) + (cam.transform.right * horizontalInput);

        //Calculate the movement direction
        moveDirection = (Vector3.forward * verticalInput) + (Vector3.right * horizontalInput);

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.deltaTime);
        }

        //Player can only move if they are not aiming their gun
        if (!aiming)
        {
            //Moves the player in the calculated direction at an increased movement speed
            rb.AddForce((moveDirection.normalized * moveSpeed * 10f), ForceMode.Force);
            //transform.rotation = Quaternion.LookRotation(moveDirection.normalized);
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
