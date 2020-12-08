using UnityEngine;
using System.Collections;

public class CharacterMovemenetController : MonoBehaviour {

	private Rigidbody2D rigidboy;
    private Animator anim;

    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public float maxSpeed = 2f;
	public float jumpForce = 2f;
	
	public static bool facingRight = true;

    public Transform fallDeathCheck = null;
    public Transform uppDeathCheck = null;
    public Transform xDeathCheck = null;

    float timeSpentIdle = 0f;
    float maxIdleTime = 5f;
    public GameObject gameOverText, restartButton;
    // Use this for initialization
    void Start () {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        rigidboy = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		//If there's any vertical movement (e.g: right of left arrow pressed
		float move = Input.GetAxis("Horizontal");
		//Add vertical velocity
		this.rigidboy.velocity = 
            new Vector2(move*maxSpeed, this.rigidboy.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(this.rigidboy.velocity.x));

        if(Mathf.Abs(move) > 0f )
            anim.SetBool("IsWalking", true);
        else
            anim.SetBool("IsWalking", false);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !facingRight)
		{
			// ... flip the player.
			flip();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (move < 0 && facingRight)
		{
			// ... flip the player.
			flip();
		}
		
		//if Jump button is pressed
		if (Input.GetButtonDown("Jump")) {
			//Add vertical force to the character
			rigidboy.velocity = new Vector2(0, jumpForce); 
		}

        if(transform.position.y < fallDeathCheck.transform.position.y)
        {
            GameObject.FindGameObjectWithTag("GameManager").
                GetComponent<RespawnController>().respawn();
        }
        if (transform.position.y > uppDeathCheck.transform.position.y)
        {
            GameObject.FindGameObjectWithTag("GameManager").
                GetComponent<RespawnController>().respawn();
        }
        if (transform.position.x < xDeathCheck.transform.position.x)
        {
            GameObject.FindGameObjectWithTag("GameManager").
                GetComponent<RespawnController>().respawn();
        }

        bool grounded = 
            Physics2D.OverlapCircle(
                groundCheck.position,
                groundRadius,
                whatIsGround);

        anim.SetBool("Grounded", grounded);


        timeSpentIdle += Time.fixedDeltaTime;
        if(timeSpentIdle > maxIdleTime)
        {
            timeSpentIdle = 0f;
            anim.SetTrigger("Bored");
        }
    }


    private void flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            AudioManager.instance.PlaySound("GameOver");
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
            ScoreScript.scoreValue = 0;
        }
    }
}
