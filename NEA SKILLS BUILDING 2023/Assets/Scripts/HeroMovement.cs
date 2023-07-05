using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroMovement : MonoBehaviour {
	Rigidbody2D rb;
	float speed;
	public int lives;
	public bool vulnerable;
	public bool grounded;
	public int jumps;
	public float direction;
	public int dash;
	public GameObject particleSystem;
	public bool invincible;
	public GameObject enemy;
	public bool temporaryinv;
	// Use this for initialization
	void Start () {
		lives = 3;
		speed = 8.1f;
		vulnerable = false;
		grounded = false;
		jumps = 1;
		rb = GetComponent<Rigidbody2D> ();
		direction = 0f;
		dash = 1;
		invincible = false;
		temporaryinv = false;
		enemy = GameObject.FindGameObjectWithTag ("enemy");
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			if (invincible == false) {
				transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * speed, 0, 0);
				direction = Input.GetAxisRaw ("Horizontal");
			}
		}
		grounded = CheckGround ();
		if (grounded) {
			jumps = 1;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (invincible == false) {
				if (SceneManager.GetActiveScene ().name == "Level 3") {
					if (grounded) {
						jumps = 1;
						rb.AddForce (Vector2.up * 400);
					} else if (jumps > 0) {
						rb.AddForce (Vector2.up * 500);
						jumps = jumps - 1;
					}
				} else {
					rb.AddForce (Vector2.up * 300);
				}
			}
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			if(invincible == false){
				if (grounded == false) {
					rb.AddForce (Vector2.down * 25);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if (dash > 0) {
				dash = dash - 1;
				invincible = true;
				temporaryinv = true;
				rb.gravityScale = 0;
				rb.velocity = Vector2.zero;
				rb.AddForce (Vector2.right * 600 * direction);
				Physics2D.IgnoreLayerCollision (10, 9, true);
				StartCoroutine (DashWait ());
				StartCoroutine (DashCooldown ());
			}
		}
	}
	void resetPosition(){
		transform.SetPositionAndRotation( new Vector3 (-5.62f, 0.78f, 0), Quaternion.identity);
		setLives ();
	}
	public void setLives(){
		lives -= 1;
		if (lives <= 0 || vulnerable == true) {
			Debug.Log ("End of game");
			SceneManager.LoadScene ("Lost");
		}
	}
	private void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "extraLife") {
			lives += 1;
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "vulnerable") {
			Destroy (other.gameObject);
			vulnerable = true;
			Debug.Log ("vulnerable = true!");
			StartCoroutine ("VulnerableDeBuff");
		}
	}
	IEnumerator VulnerableDeBuff()
	{
		yield return new WaitForSeconds(2f);
		vulnerable = false;
		Debug.Log ("vulnerable = false!");
	}

	private bool CheckGround(){
		RaycastHit2D hit;
		LayerMask layerMask;
		layerMask = LayerMask.GetMask ("ground");
		hit = Physics2D.Raycast (transform.position, Vector2.down,1f,layerMask);
		return (hit.collider != null && hit.collider.tag == "floor");
	}
	IEnumerator DashWait(){
		yield return new WaitForSecondsRealtime(0.5f);
		rb.velocity = Vector2.zero;
	}
	IEnumerator DashCooldown(){
		var part = GetComponent<ParticleSystem> ();
		part.Play ();
		yield return new WaitForSecondsRealtime (0.7f);
		invincible = false;
		rb.gravityScale = 1;
		Physics2D.IgnoreLayerCollision (10, 9, false);
		yield return new WaitForSecondsRealtime (0.3f);
		part.Stop ();
		temporaryinv = false;
		yield return new WaitForSecondsRealtime (2);
		dash = 1;
	}
}
