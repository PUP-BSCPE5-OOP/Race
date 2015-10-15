using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour {
	public float carSpeed;
	Vector3 position;

	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;
		// position.x = Mathf.Clamp (position.x, -9.98f, 9.08f);
		// transform.position = position;

		if (Input.GetButtonDown ("Horizontal") && Input.GetAxisRaw("Horizontal") < 0.3f) {
			position.x -= 9.8f;
		} else if (Input.GetButtonDown ("Horizontal") && Input.GetAxisRaw("Horizontal") > 0.3f) {
			position.x += 9.8f;
		}
		
		position.x = Mathf.Clamp (position.x, -9.5f,10.1f);
		transform.position = position;

		// position = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		// GetComponent<Rigidbody> ().AddForce (position * carSpeed);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "eCar") {
            GameManager.Instance.gameOver = true;
            Scoring.Instance.stopScore = true;
            GameManager.Instance.AddScoreToDb();
            Destroy(gameObject);
		}
	}
}
