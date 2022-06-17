using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference inputMovement;
    [SerializeField] private InputActionReference inputJump;
    
    [Header("Player Settings")]
    [SerializeField] public float playerSpeed = 2.0f;

    [SerializeField] public float defaultPlayerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 4.0f;
    
    private CharacterController controller;
    
    public Vector3 playerVelocity;
    public Vector3 lastPosition;
    
    private bool groundedPlayer;
    private Transform mainCam;

    private void OnEnable()
    {
        inputMovement.action.Enable();
        inputJump.action.Enable();

        playerSpeed = defaultPlayerSpeed;
    }

    private void OnDisable()
    {
        inputMovement.action.Disable();
        inputJump.action.Disable();
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCam = Camera.main.transform;
        
        // set cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        lastPosition = transform.position;
        
        // get movement input
        Vector2 movement = inputMovement.action.ReadValue<Vector2>();
        // get movement vector
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        // move by forward cam dir
        move = mainCam.forward * move.z + mainCam.right * move.x;
        move.y = 0.0f;
        // move the controller
        controller.Move(move * (Time.deltaTime * playerSpeed));

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (inputJump.action.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        
        // apply rotation
        if (movement != Vector2.zero)
        {
            float desiredAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + mainCam.eulerAngles.y;
            Quaternion rot = Quaternion.Euler(0f, desiredAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotationSpeed);
        }
    }

    public void ApplyDebuffSpeed()
    {
        playerSpeed = defaultPlayerSpeed / 2;
    }

    public void ExpelDebuffSpeed()
    {
        playerSpeed = defaultPlayerSpeed;
    }
}
