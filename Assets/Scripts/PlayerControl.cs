using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1;
    
    
    
    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    public float minY = 0;
    public float maxY = 4;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
    }
       
    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
        Vector2 position = rb.position;
        position.y = Mathf.Clamp(position.y, minY,maxY);
        rb.position = position;
    }
       

    
}
