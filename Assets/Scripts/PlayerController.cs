using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    public float maxSpeed = 10f;
    bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float jumpForce = 700f;

    bool doubleJump = false;  

    float groundRadius = 0.2f;

    Animator anim;

	// Use this for initialization
	void Start () 
    {	
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        if (grounded)
        {
            doubleJump = false;
        }

        anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

        float move = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(move*maxSpeed, rigidbody2D.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));

        if(move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Update()
    {
        if ((grounded || !doubleJump) && Input.GetButtonDown("Jump"))
        {
            if (!doubleJump && !grounded)
            {
                doubleJump = true;
            }
            anim.SetBool ("Ground", false);

            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
