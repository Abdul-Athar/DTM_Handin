using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement variables
    public float speed;
    public float jumpForce;
    private float moveInput;

    // check to see if player is on ground (use "ground" tags/layers)
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;

    // check if player is facing right, used to flip face of player if facing left
    private bool facingRight = true;


    // double jump variables. (public, so can change easily inobject menu.)
    private int extraJumps;
    public int extraJumpsValue;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // check to see if player is grounded.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // use default horizonally moving input keys (A,D OR right/left arrow keys)
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // if player is not facing right and the move input is more than 0, 
        if(facingRight == false && moveInput > 0)
        {
            //call the flip function
            Flip();
        }
        // otherwise if player is facing right, but movement input is less than 0,
        else if(facingRight == true && moveInput < 0)
        {
            // call the flip function
            Flip();
        }
    }

    void Update()
    {
        // check to see if player is on the ground.
        if (isGrounded == true)
        {
            // how many extra jumps player has left
            extraJumps = extraJumpsValue;
        }

        // if jump (up arrow OR W key OR spacebar) keys are pressed and if player has more than 0 jumps left
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0 || Input.GetKeyDown(KeyCode.W) && extraJumps > 0 || Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            // move the player object up vy the jump force variable.
            // take a jump away
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        // otherwise if player presses the same keys,
        // but is grounded, than the first jump does not count.
        // this allows us to only count how many EXTRA jumps we want the player to have.
        else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0 && isGrounded == true || Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true || Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            // move player up by the jump force variable.
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    // flip function "flips" the face of the player object.
    void Flip()
    {
        // facing right is not equal to facing right,
        // use 3D scaler
        // set scaler to -1 in the x axis (flips face across)
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
