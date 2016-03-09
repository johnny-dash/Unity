using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countTxT;
	public Text winTxT;

	private Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCountValue();
		winTxT.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertial = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertial);

		rb.AddForce (movement * speed);
	}

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1; 
			setCountValue();
		}
	}

	void setCountValue()
	{
		countTxT.text = "Count: " + count.ToString();
		if (count >= 9) {
			winTxT.text = "You Win!!";
		}
	}
}	
