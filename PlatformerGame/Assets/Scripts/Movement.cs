using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb2d;

    public float runSpeed = 5f;
    private float horizontalMovement;
    public float jumpHeight = 5f;
    private float verticalMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Jump");
    }

    private void FixedUpdate() {
        rb2d.velocity = new Vector2(horizontalMovement * runSpeed, rb2d.velocity.y);
        rb2d.velocity = new Vector2(rb2d.velocity.x, verticalMovement * jumpHeight);

    }
}
