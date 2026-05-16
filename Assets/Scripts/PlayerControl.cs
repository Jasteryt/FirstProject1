using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1;
    private Vector3 velocity;
    public float gravity = -9.81f;
    private Rigidbody2D rb;
    private float horizontal;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
    }
       
    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
       

    
}
