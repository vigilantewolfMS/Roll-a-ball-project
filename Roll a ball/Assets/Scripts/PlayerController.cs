using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	private Rigidbody rb;
	public float speed;
	private int count;
	public Text countText;
	public Text winText;
	public float distToGround = 0.5f;
	private bool isGrounded;
	public int jumpForce = 50;
	
	void Start(){
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void FixedUpdate()
	{
		isGrounded = Physics.Raycast (transform.position, Vector3.down, distToGround);

			if(Input.GetKey(KeyCode.Space) && isGrounded){
				rb.AddForce(0,jumpForce,0);
			}

			
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
		
		rb.AddForce (movement * speed);
	}


	
void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
		
	}
	void SetCountText(){
		countText.text = "Count: "+ count.ToString();
		if (count>=12)
		{
			winText.text = "You Win!";
		}
	}
			

}
