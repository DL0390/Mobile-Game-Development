using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] float speed = 5f;
    [SerializeField] private float rotationSpeed;
    public bool canFire;
    InputAction moveAction;
    Camera mainCamera;
    Rigidbody2D rb;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {   
        // makes player move
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        GetComponent<Rigidbody2D>().linearVelocity = speed * moveInput;


        // checks if player is moving to play running animation
        if (moveInput.sqrMagnitude > 0.01f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
            //rb.linearVelocity = Vector2.zero;
        }

            PlayerRotation();

        // checks mouse click to trigger shooting animation
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }

    }

    void PlayerRotation()
    {
       // Player rotation based on mouse position
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0f;

        Vector2 direction = mouseWorldPos - transform.position;

        // works out the angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void FixedUpdate()
    {
        // an attempt to stop player from drifting after collision
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput.sqrMagnitude < 0.1f)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            rb.linearVelocity = moveInput * speed;
        }
    }

        public class MobileMoveReader : MonoBehaviour
    {
        [SerializeField] InputActionReference moveAction;

        void OnEnable() => moveAction.action.Enable();
        void OnDisable() => moveAction.action.Disable();

    }
}

