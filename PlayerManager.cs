using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
	[SerializeField] float movementSpeed = 5f;
	
	Rigidbody2D rb;
	SpriteRenderer sp;
	CircleCollider2D cc;
	
	// == JUMP ==
	public float jumpForce = 5.0f;
	bool jump = false;
	bool isGrounded = true;
	// == /JUMP ==
	
	public Text teksSkor;
	int skor = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
		sp = this.GetComponent<SpriteRenderer>();
		cc = this.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {	
		// == JUMP ==
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
			Jump();
		}
		// == /JUMP ==
    }
	
	void FixedUpdate()
    {
		float moveHorizontal = Input.GetAxis("Horizontal");
		//float moveVertical = Input.GetAxis("Vertical");
		
		if(moveHorizontal > 0){
			sp.flipX = false;
			this.transform.Translate(Vector3.right * movementSpeed * Time.fixedDeltaTime);
		}
		else if(moveHorizontal < 0){
			sp.flipX = true;
			this.transform.Translate(Vector3.left  * movementSpeed * Time.fixedDeltaTime);
		}	
    }
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Coin")){
			Destroy(collision.gameObject);
			skor++;
			teksSkor.text = "Skor: " + skor;
		}
		
		if(collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;
		}
		
	}

	
	void Jump()
	{
		Debug.Log("jump");
		rb.velocity = (Vector2.up * 2) * jumpForce;
		jump = false;
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = false;
		}
	}


}

