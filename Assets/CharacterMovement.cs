using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float jumpForce = 5.0f;
    public float speed = 1f;

    private Rigidbody2D rb;

    public bool facingRight = true;
    
    // Use this for initialization
    void Start () {
        


        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown("Vertical") &&
            Input.GetAxis("Vertical")>0)
        {
            rb.AddForce(new Vector2(0f, 1f)*jumpForce,
                        ForceMode2D.Impulse);
        }

        float move = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector2(move, 0) * speed,
                    ForceMode2D.Force);


        if (facingRight && move < 0) {
            flip();
        } else if (!facingRight && move > 0) {
            flip();
        }
	}

    private void flip()
    {
        Transform tr = GetComponent<Transform>();
        Vector3 old_scale = tr.localScale;
        old_scale.x *= -1f;
        tr.localScale = old_scale;

        facingRight = !facingRight;
    }
   
}
