using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    public float minY = 0;
    public float maxY = 4;
    public InputActionReference moveAction;
    private float moveInput;
    private InputActionReference jumpAction;
    private float jumpInput;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        moveInput = moveAction.action.ReadValue<float>();
        jumpInput = jumpAction.action.ReadValue<float>();
        
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
        rb.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
        Vector2 position = rb.position;
        position.y = Mathf.Clamp(position.y, minY,maxY);
        rb.position = position;
    }
       

    
}
