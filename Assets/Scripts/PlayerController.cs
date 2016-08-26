using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public float speed;

    private Rigidbody2D rb2d;
    
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (Input.GetKey(left))
        {
            transform.localPosition = new Vector3(transform.localPosition.x - speed, transform.localPosition.y, transform.localPosition.z);
        }
        else if (Input.GetKey(right))
        {
            transform.localPosition = new Vector3(transform.localPosition.x + speed, transform.localPosition.y, transform.localPosition.z);
        }

        if (Input.GetKey(up))
        {
            rb2d.AddForce(new Vector2(0f, 50f));
        }
    }
}
