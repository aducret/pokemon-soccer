using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    public Text score;

    public float speed;
    public float jumpSpeed;

    private Rigidbody2D rb;
    private bool isJumping = false;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        score = GetComponent<Text>();
	}
    
	void Update ()
    {   
        if (Input.GetKey(left))
        {
            transform.localPosition = new Vector2(transform.localPosition.x - speed, transform.localPosition.y);
        }
        else if (Input.GetKey(right))
        {
            transform.localPosition = new Vector2(transform.localPosition.x + speed, transform.localPosition.y);
        }

        if (rb.position.y <= 0)
        {
            isJumping = false;
        }

        // TODO: Deberia chequear si esta tocando un objeto para poder saltar.
        // Lo que hago ahora es ver si estoy abajo del 0.
        if (Input.GetKey(up) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(0f, jumpSpeed));
        }

    }
    

}
