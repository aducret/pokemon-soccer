using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    public float speed;
    public float jumpForce;
    public int maxNumOfJumps = 1;

    private Rigidbody2D rb;
    private bool jumpPressed = false;
    private int jumpNumber = 0;    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
	}
    
	void Update()
    {
        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if (jumpNumber < maxNumOfJumps && Input.GetKeyDown(up))
        {
            jumpPressed = true;
            jumpNumber++;
        }
    }

    void FixedUpdate()
    {
        if (jumpPressed)
        {
            rb.AddForce(Vector2.up * jumpForce);
            jumpPressed = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        jumpNumber = 0;
    }

}
