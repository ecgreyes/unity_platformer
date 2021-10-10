using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement Variables
    private Rigidbody2D rb2d;
    public float runSpeed = 5f;
    private float horizontalMovement;
    public float jumpHeight = 5f;
    private float verticalMovement;

    //Grounded Variables
    private bool isGrounded;
    public Transform groundCheck;
    public float radGrounded;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded){
            rb2d.velocity = new Vector2(rb2d.velocity.x,jumpHeight);
        }

        if (horizontalMovement > 0) {
            transform.localScale = new Vector3(1f,1f,1f);
        } else if (horizontalMovement < 0){
            transform.localScale = new Vector3(-1f,1f,1f);
        }
    }

    private void FixedUpdate() {
        rb2d.velocity = new Vector2(horizontalMovement * runSpeed, rb2d.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radGrounded, whatIsGround);
    }
}
