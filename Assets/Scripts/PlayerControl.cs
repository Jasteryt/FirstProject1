using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1;
    public float flySpeed = 5f;
    public bool isFlying ;
    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    public float minY = 0;
    public float maxY = 4;
    public InputActionReference moveAction;
    private Vector2 moveInput;
    public InputActionReference jumpAction;
    private Vector2 jumpInput;
    public float fallSpeed = 2f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        
    }
    private void Update()
    {
        moveInput = moveAction.action.ReadValue<Vector2>();
        isFlying = jumpAction.action.IsPressed();
        
    }
    
    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }
    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

       
    
    private void FixedUpdate()
    {
        float yVelocity = rb.linearVelocity.y;
        if (isFlying)
        {
            yVelocity = flySpeed;
        }
        else
        {
            yVelocity = -fallSpeed;
        }
        
        rb.linearVelocity = new Vector2(moveInput.x * speed, yVelocity);
        Vector2 position = rb.position;
        position.y = Mathf.Clamp(position.y, minY,maxY);
        rb.position = position;
    }
       

    
}
